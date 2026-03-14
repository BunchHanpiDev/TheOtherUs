using System;
using HarmonyLib;
using UnityEngine;
using TheOtherRoles.Modules;

namespace TheOtherRoles.Patches {

    internal static class RendererHelper {
        /// <summary>
        /// 通过实例字典查找 renderer，不调用任何 GetComponent。
        /// popUp 为 null 或字典中无对应记录时返回 null。
        /// </summary>
        internal static TORAnnouncementImageRenderer GetRenderer(AnnouncementPopUp popUp) {
            if (popUp == null) return null;
            TORAnnouncementImageRenderer.ActiveInstances
                .TryGetValue(popUp.gameObject.Pointer, out var r);
            return r;
        }
    }

    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.UpdateAnnouncementText))]
    public static class AnnouncementPopUpUpdateTextImagePatch {
        public static void Postfix(AnnouncementPopUp __instance, int id, bool previewOnly) {
            try {
                var renderer = RendererHelper.GetRenderer(__instance);
                if (renderer == null) return;

                if (previewOnly || id != ModUpdater.TorAnnouncementNumberPublic) {
                    renderer.ClearImages();
                    return;
                }

                if (ModUpdater.TryGetCachedSprites(id, out var sprites)
                    && sprites != null && sprites.Count > 0) {
                    var bodyText = __instance.AnnouncementBodyText;
                    if (bodyText == null) return;
                    renderer.Initialize(bodyText);
                    renderer.ShowImages(sprites);
                }
            } catch (Exception ex) {
                TheOtherRolesPlugin.Logger.LogWarning(
                    $"[AnnouncementImagePatch] UpdateAnnouncementText failed: {ex}");
            }
        }
    }

    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.Update))]
    public static class AnnouncementPopUpUpdateImagePatch {
        public static void Postfix(AnnouncementPopUp __instance) {
            try {
                var renderer = RendererHelper.GetRenderer(__instance);
                if (renderer == null || !renderer.HasImages) return;

                var scroller = __instance.TextScroller;
                if (scroller == null) return;

                float extra = renderer.GetExtraScrollHeight();
                if (extra <= 0f) return;

                scroller.SetBoundsMax(renderer.GetTextHeight() + extra, 0f);
            } catch (Exception ex) {
                TheOtherRolesPlugin.Logger.LogWarning(
                    $"[AnnouncementImagePatch] Update failed: {ex}");
            }
        }
    }

    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.OnDisable))]
    public static class AnnouncementPopUpOnDisableImagePatch {
        public static void Postfix(AnnouncementPopUp __instance) {
            try {
                var renderer = RendererHelper.GetRenderer(__instance);
                renderer?.ClearImages();
            } catch (Exception ex) {
                TheOtherRolesPlugin.Logger.LogWarning(
                    $"[AnnouncementImagePatch] OnDisable failed: {ex}");
            }
        }
    }
}
