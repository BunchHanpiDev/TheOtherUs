using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BepInEx.Unity.IL2CPP.Utils;
using UnityEngine;
using UnityEngine.Networking;

namespace TheOtherRoles.Modules {

    /// <summary>
    /// 从 GitHub Release body 中提取图片链接并下载为 Sprite。
    /// 支持两种格式：
    ///   - Markdown: ![alt](url)
    ///   - HTML:     &lt;img ... src="url" ... /&gt;
    /// GitHub user-attachments 链接会 302 重定向到 S3，UnityWebRequest 会自动跟随。
    /// 20 秒超时后回退到嵌入的 Banner.png。
    /// </summary>
    internal static class GitHubImageLoader {
        // 匹配 Markdown 图片: ![alt](url)
        private static readonly Regex MarkdownImgRegex = new Regex(
            @"!\[(?:[^\]]*)\]\((?<url>https?://[^\s\)""]+)\)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // 匹配 HTML img 标签中的 src 属性（单双引号均可）
        private static readonly Regex HtmlImgSrcRegex = new Regex(
            @"<img\b[^>]*\bsrc\s*=\s*(?:""(?<url>[^""]+)""|'(?<url>[^']+)')[^>]*/?>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private const float TimeoutSeconds = 20f;
        private const float SpritePixelsPerUnit = 100f;

        // 占位符格式，与 TOU AnnouncementImageRenderer 配合使用
        internal const string PlaceholderPrefix = "[[img:";
        internal const string PlaceholderSuffix = "]]";
        internal const int PlaceholderLineCount = 10;
        private const string PlaceholderAlphaStart = "<alpha=#00>";
        private const string PlaceholderAlphaEnd = "<alpha=#FF>";

        /// <summary>
        /// 从 GitHub Release body 中提取所有图片 URL。
        /// 同时替换原文中的图片语法为不可见占位符，供渲染器定位。
        /// </summary>
        /// <param name="body">GitHub API 返回的 body 字段原始文本（含 \r\n）</param>
        /// <param name="processedBody">处理后的公告文本（图片位置替换为占位符）</param>
        /// <returns>提取到的图片 URL 列表（按出现顺序）</returns>
        internal static List<string> ExtractAndReplace(string body, out string processedBody) {
            var urls = new List<string>();
            if (string.IsNullOrEmpty(body)) {
                processedBody = body ?? string.Empty;
                return urls;
            }

            // 先处理 HTML <img> 标签，再处理 Markdown
            string text = HtmlImgSrcRegex.Replace(body, match => {
                string url = match.Groups["url"].Value.Trim();
                if (!string.IsNullOrEmpty(url) && IsWebUrl(url)) {
                    urls.Add(url);
                    return BuildPlaceholder(urls.Count - 1);
                }
                return string.Empty;
            });

            text = MarkdownImgRegex.Replace(text, match => {
                string url = match.Groups["url"].Value.Trim();
                if (!string.IsNullOrEmpty(url) && IsWebUrl(url)) {
                    urls.Add(url);
                    return BuildPlaceholder(urls.Count - 1);
                }
                return string.Empty;
            });

            processedBody = text;
            return urls;
        }

        /// <summary>
        /// 协程：下载指定 URL 的图片并返回 Sprite。
        /// 失败或超时时返回 null。
        /// </summary>
        internal static IEnumerator DownloadSprite(string url, Action<Sprite> callback) {
            if (string.IsNullOrEmpty(url)) {
                callback?.Invoke(null);
                yield break;
            }

            var www = new UnityWebRequest();
            www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
            www.SetUrl(url);
            www.downloadHandler = new DownloadHandlerBuffer();

            var operation = www.SendWebRequest();
            float elapsed = 0f;

            while (!operation.isDone) {
                elapsed += Time.unscaledDeltaTime;
                if (elapsed >= TimeoutSeconds) {
                    www.Abort();
                    TheOtherRolesPlugin.Logger.LogWarning($"[GitHubImageLoader] Timeout downloading image: {url}");
                    www.downloadHandler?.Dispose();
                    www.Dispose();
                    callback?.Invoke(null);
                    yield break;
                }
                yield return new WaitForEndOfFrame();
            }

            if (www.isNetworkError || www.isHttpError) {
                TheOtherRolesPlugin.Logger.LogWarning($"[GitHubImageLoader] HTTP error ({www.responseCode}) for: {url} — {www.error}");
                www.downloadHandler?.Dispose();
                www.Dispose();
                callback?.Invoke(null);
                yield break;
            }

            var data = www.downloadHandler?.GetUnstrippedData();
            www.downloadHandler?.Dispose();
            www.Dispose();

            if (data == null || data.Length == 0) {
                callback?.Invoke(null);
                yield break;
            }

            var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            texture.wrapMode = TextureWrapMode.Clamp;
            if (!ImageConversion.LoadImage(texture, data, false)) {
                TheOtherRolesPlugin.Logger.LogWarning($"[GitHubImageLoader] Failed to decode image from: {url}");
                callback?.Invoke(null);
                yield break;
            }

            var sprite = Sprite.Create(
                texture,
                new Rect(0f, 0f, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                SpritePixelsPerUnit);

            callback?.Invoke(sprite);
        }

        // ── 辅助方法 ────────────────────────────────────────────────

        private static bool IsWebUrl(string url) =>
            url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

        private static string BuildPlaceholder(int index) {
            string token = $"{PlaceholderPrefix}{index}{PlaceholderSuffix}";
            string invisible = $"{PlaceholderAlphaStart}{token}{PlaceholderAlphaEnd}";
            var sb = new System.Text.StringBuilder();
            sb.Append('\n');
            for (int i = 0; i < PlaceholderLineCount; i++) {
                sb.Append(invisible);
                if (i < PlaceholderLineCount - 1) sb.Append('\n');
            }
            sb.Append('\n');
            return sb.ToString();
        }
    }
}
