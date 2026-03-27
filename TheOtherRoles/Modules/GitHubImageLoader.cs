using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BepInEx.Unity.IL2CPP.Utils;
using UnityEngine;
using UnityEngine.Networking;

namespace TheOtherRoles.Modules
{
	internal static class GitHubImageLoader
	{
		// 匹配 Markdown 图片：允许跨行、允许标题
		private static readonly Regex MarkdownImgRegex = new Regex(
			@"!\[[^\]]*\]\s*\(\s*(?<url>https?://[^\s\)]+)\s*(?:[""'][^""']*[""'])?\s*\)",
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		private static readonly Regex HtmlImgSrcRegex = new Regex(
			@"<img\b[^>]*\bsrc\s*=\s*(?:""(?<url>[^""]+)""|'(?<url>[^']+)')[^>]*/?>",
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		private const float TimeoutSeconds = 20f;
		private const float SpritePixelsPerUnit = 100f;

		internal const string PlaceholderPrefix = "[[img:";
		internal const string PlaceholderSuffix = "]]";
		internal const int PlaceholderLineCount = 10;
		private const string PlaceholderAlphaStart = "<alpha=#00>";
		private const string PlaceholderAlphaEnd = "<alpha=#FF>";

		internal static List<string> ExtractAndReplace(string body, out string processedBody)
		{
			var urls = new List<string>();
			if (string.IsNullOrEmpty(body))
			{
				processedBody = body ?? string.Empty;
				return urls;
			}

			string text = body.Replace("\r\n", "\n");

			text = HtmlImgSrcRegex.Replace(text, match =>
			{
				string url = match.Groups["url"].Value.Trim();
				if (!string.IsNullOrEmpty(url) && IsWebUrl(url))
				{
					urls.Add(url);
					return BuildPlaceholder(urls.Count - 1);
				}
				return string.Empty;
			});

			text = MarkdownImgRegex.Replace(text, match =>
			{
				string url = match.Groups["url"].Value.Trim();
				if (!string.IsNullOrEmpty(url) && IsWebUrl(url))
				{
					urls.Add(url);
					return BuildPlaceholder(urls.Count - 1);
				}
				return string.Empty;
			});

			processedBody = text;
			return urls;
		}

		internal static IEnumerator DownloadSprite(string url, Action<Sprite> callback)
		{
			if (string.IsNullOrEmpty(url))
			{
				callback?.Invoke(null);
				yield break;
			}

			var www = new UnityWebRequest();
			www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
			www.SetUrl(url);
			www.downloadHandler = new DownloadHandlerBuffer();

			var operation = www.SendWebRequest();
			float elapsed = 0f;

			while (!operation.isDone)
			{
				elapsed += Time.unscaledDeltaTime;
				if (elapsed >= TimeoutSeconds)
				{
					www.Abort();
					TheOtherRolesPlugin.Logger.LogWarning($"[GitHubImageLoader] Timeout downloading image: {url}");
					www.downloadHandler?.Dispose();
					www.Dispose();
					callback?.Invoke(null);
					yield break;
				}
				yield return new WaitForEndOfFrame();
			}

			if (www.isNetworkError || www.isHttpError)
			{
				TheOtherRolesPlugin.Logger.LogWarning($"[GitHubImageLoader] HTTP error ({www.responseCode}) for: {url} — {www.error}");
				www.downloadHandler?.Dispose();
				www.Dispose();
				callback?.Invoke(null);
				yield break;
			}

			var data = www.downloadHandler?.GetUnstrippedData();
			www.downloadHandler?.Dispose();
			www.Dispose();

			if (data == null || data.Length == 0)
			{
				callback?.Invoke(null);
				yield break;
			}

			var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
			texture.wrapMode = TextureWrapMode.Clamp;
			texture.filterMode = FilterMode.Point;

			if (!ImageConversion.LoadImage(texture, data, false))
			{
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

		private static bool IsWebUrl(string url) =>
			url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
			url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

		private static string BuildPlaceholder(int index)
		{
			string token = $"{PlaceholderPrefix}{index}{PlaceholderSuffix}";
			string invisible = $"{PlaceholderAlphaStart}{token}{PlaceholderAlphaEnd}";
			var sb = new System.Text.StringBuilder();
			sb.Append('\n');
			for (int i = 0; i < PlaceholderLineCount; i++)
			{
				sb.Append(invisible);
				if (i < PlaceholderLineCount - 1) sb.Append('\n');
			}
			sb.Append('\n');
			return sb.ToString();
		}
	}
}