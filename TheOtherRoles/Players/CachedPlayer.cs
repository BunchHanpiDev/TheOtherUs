using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace TheOtherRoles.Players;

public class CachedPlayer
{
	public static readonly Dictionary<IntPtr, CachedPlayer> PlayerPtrs = new();
	public static readonly List<CachedPlayer> AllPlayers = new();
	public static CachedPlayer LocalPlayer;

	public Transform transform;
	public PlayerControl PlayerControl;
	public PlayerPhysics PlayerPhysics;
	public CustomNetworkTransform NetTransform;

	// 直接引用 PlayerControl 的属性，不再储存副本
	public GameData.PlayerInfo Data => PlayerControl?.Data;
	public byte PlayerId => PlayerControl?.PlayerId ?? byte.MaxValue;

	public static implicit operator bool(CachedPlayer player)
	{
		return player != null && player.PlayerControl;
	}

	public static implicit operator PlayerControl(CachedPlayer player) => player.PlayerControl;
	public static implicit operator PlayerPhysics(CachedPlayer player) => player.PlayerPhysics;
}

[HarmonyPatch]
public static class CachedPlayerPatches
{
	[HarmonyPatch]
	private class CacheLocalPlayerPatch
	{
		[HarmonyTargetMethod]
		public static MethodBase TargetMethod()
		{
			var type = typeof(PlayerControl).GetNestedTypes(AccessTools.all).FirstOrDefault(t => t.Name.Contains("Start"));
			return AccessTools.Method(type, nameof(IEnumerator.MoveNext));
		}

		[HarmonyPostfix]
		public static void SetLocalPlayer()
		{
			CachedPlayer.LocalPlayer = CachedPlayer.AllPlayers.FirstOrDefault(p => p.PlayerControl.Pointer == PlayerControl.LocalPlayer.Pointer);
		}
	}

	[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Awake))]
	[HarmonyPostfix]
	public static void CachePlayerPatch(PlayerControl __instance)
	{
		if (__instance.notRealPlayer) return;
		var player = new CachedPlayer
		{
			transform = __instance.transform,
			PlayerControl = __instance,
			PlayerPhysics = __instance.MyPhysics,
			NetTransform = __instance.NetTransform
		};
		CachedPlayer.AllPlayers.Add(player);
		CachedPlayer.PlayerPtrs[__instance.Pointer] = player;

#if DEBUG
		foreach (var cachedPlayer in CachedPlayer.AllPlayers)
		{
			if (!cachedPlayer.PlayerControl || !cachedPlayer.PlayerPhysics || !cachedPlayer.NetTransform || !cachedPlayer.transform)
			{
				TheOtherRolesPlugin.Logger.LogError($"CachedPlayer {cachedPlayer.PlayerControl.name} has null fields");
			}
		}
#endif
	}

	[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.OnDestroy))]
	[HarmonyPostfix]
	public static void RemoveCachedPlayerPatch(PlayerControl __instance)
	{
		if (__instance.notRealPlayer) return;
		CachedPlayer.AllPlayers.RemoveAll(p => p.PlayerControl.Pointer == __instance.Pointer);
		CachedPlayer.PlayerPtrs.Remove(__instance.Pointer);
	}

	// 移除了以下补丁，因为不再需要更新 Data 和 PlayerId
	// [HarmonyPatch(typeof(GameData), nameof(GameData.Deserialize))]
	// [HarmonyPatch(typeof(GameData), nameof(GameData.AddPlayer))]
	// [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Deserialize))]
}