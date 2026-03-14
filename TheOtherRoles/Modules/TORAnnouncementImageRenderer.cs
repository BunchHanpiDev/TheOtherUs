using System;
using System.Collections;
using System.Collections.Generic;
using BepInEx.Unity.IL2CPP.Utils;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace TheOtherRoles.Modules {

    /// <summary>
    /// 附加到 AnnouncementPopUp 上，负责在公告正文的占位符位置渲染图片。
    /// 设计参考 SuperNewRoles 的 AnnouncementImageRenderer，精简为仅支持静态图片。
    /// </summary>
    public class TORAnnouncementImageRenderer : MonoBehaviour {
        static TORAnnouncementImageRenderer() =>
            ClassInjector.RegisterTypeInIl2Cpp<TORAnnouncementImageRenderer>();

        internal static readonly System.Collections.Generic.Dictionary<IntPtr, TORAnnouncementImageRenderer>
            ActiveInstances = new();

        private void OnEnable()  => ActiveInstances[gameObject.Pointer] = this;
        private void OnDisableInternal() { ActiveInstances.Remove(gameObject.Pointer); }

        private const float MaxImageWidth     = 9.88f;
        private const float MaxImageHeight    = 7.54f;
        private const float MaxImageScale     = 4.68f;
        private const float SpritePixelsPerUnit = 100f;

        private const string PlaceholderPrefix = GitHubImageLoader.PlaceholderPrefix;
        private const string PlaceholderSuffix = GitHubImageLoader.PlaceholderSuffix;

        private TextMeshPro _bodyText;
        private Vector3?    _defaultBodyPos;
        private int         _requestToken;
        private float       _extraHeight;

        private readonly Dictionary<int, SpriteRenderer> _imageRenderers = new();

        public bool HasImages => _imageRenderers.Count > 0;

        public TORAnnouncementImageRenderer(IntPtr ptr) : base(ptr) { }

        [HideFromIl2Cpp]
        public void Initialize(TextMeshPro text) {
            _bodyText = text;
            if (_bodyText != null && !_defaultBodyPos.HasValue)
                _defaultBodyPos = _bodyText.transform.localPosition;
        }

        [HideFromIl2Cpp]
        public void ShowImages(List<Sprite> sprites) {
            ClearImagesInternal();
            if (sprites == null || sprites.Count == 0 || _bodyText == null) return;

            _requestToken++;
            StartCoroutine(PlaceImages(sprites, _requestToken).WrapToIl2Cpp());
        }

        public void ClearImages() {
            _requestToken++;
            ClearImagesInternal();
            OnDisableInternal();
        }

        public float GetExtraScrollHeight() => _extraHeight;

        public float GetTextHeight() {
            try { return _bodyText != null ? Mathf.Abs(_bodyText.GetNotDumbRenderedHeight()) : 0f; }
            catch { return 0f; }
        }

        [HideFromIl2Cpp]
        private IEnumerator PlaceImages(List<Sprite> sprites, int token) {
            yield return new WaitForEndOfFrame();
            if (token != _requestToken) yield break;

            for (int i = 0; i < sprites.Count; i++) {
                if (token != _requestToken) yield break;
                var sprite = sprites[i];
                if (sprite == null) continue;

                var renderer = CreateRenderer(sprite);
                if (renderer != null)
                    _imageRenderers[i] = renderer;
            }

            LayoutImages();
        }

        internal void LayoutImages() {
            if (_bodyText == null || _imageRenderers.Count == 0) {
                _extraHeight = 0f;
                return;
            }

            _bodyText.ForceMeshUpdate();
            var blocks  = GetPlaceholderBlocks(_bodyText.textInfo);
            float availWidth = GetAvailableWidth();
            float maxWidth   = Mathf.Min(availWidth, MaxImageWidth);
            float leftEdge   = GetLeftEdge();
            float totalExtra = 0f;

            if (maxWidth <= 0f) { _extraHeight = 0f; return; }

            float fallbackY = _bodyText.textBounds.min.y - 0.2f;

            foreach (var kvp in _imageRenderers) {
                var rend = kvp.Value;
                if (rend == null || rend.sprite == null) continue;

                float sw = rend.sprite.bounds.size.x;
                float sh = rend.sprite.bounds.size.y;
                if (sw <= 0f) continue;

                if (blocks.TryGetValue(kvp.Key, out var block)) {
                    float mh = Mathf.Min(block.Height, MaxImageHeight);
                    if (mh <= 0f || sh <= 0f) continue;
                    float sc = Mathf.Min(Mathf.Min(maxWidth / sw, mh / sh), MaxImageScale);
                    rend.transform.localScale    = new Vector3(sc, sc, 1f);
                    rend.transform.localPosition = new Vector3(leftEdge + sw * sc * 0.5f, (block.Top + block.Bottom) * 0.5f, 0f);
                } else {
                    float mh = Mathf.Min(MaxImageHeight, sh);
                    if (mh <= 0f) continue;
                    float sc = Mathf.Min(Mathf.Min(maxWidth / sw, mh / sh), MaxImageScale);
                    float h  = sh * sc;
                    rend.transform.localScale    = new Vector3(sc, sc, 1f);
                    rend.transform.localPosition = new Vector3(leftEdge + sw * sc * 0.5f, fallbackY - h * 0.5f, 0f);
                    fallbackY   -= h + 0.2f;
                    totalExtra  += h + 0.2f;
                }
            }

            _extraHeight = totalExtra;
        }

        private SpriteRenderer CreateRenderer(Sprite sprite) {
            if (_bodyText == null) return null;
            var go       = new GameObject("TORAnnouncementImage");
            go.transform.SetParent(_bodyText.transform, false);
            var rend     = go.AddComponent<SpriteRenderer>();
            rend.sprite  = sprite;
            var meshRenderer = _bodyText.GetComponent<MeshRenderer>();
            if (meshRenderer != null) {
                rend.sortingLayerID = meshRenderer.sortingLayerID;
                rend.sortingOrder   = meshRenderer.sortingOrder + 1;
            }
            rend.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            return rend;
        }

        private void ClearImagesInternal() {
            _extraHeight = 0f;
            foreach (var rend in _imageRenderers.Values)
                if (rend != null) Destroy(rend.gameObject);
            _imageRenderers.Clear();
        }

        private float GetAvailableWidth() {
            float w = 0f;
            try { w = _bodyText.rectTransform.rect.width; } catch { }
            if (w <= 0f) w = _bodyText.textBounds.size.x;
            if (w <= 0f) w = MaxImageWidth;
            return w;
        }

        private float GetLeftEdge() {
            float left = _bodyText.textBounds.size.x > 0f
                ? _bodyText.textBounds.min.x
                : _bodyText.rectTransform.rect.min.x;
            return left;
        }

        private Dictionary<int, PlaceholderBlock> GetPlaceholderBlocks(TMP_TextInfo info) {
            var blocks = new Dictionary<int, PlaceholderBlock>();
            if (info == null || info.characterCount == 0 || _bodyText == null) return blocks;

            string raw = _bodyText.text;
            if (string.IsNullOrEmpty(raw)) return blocks;

            int searchIdx = 0;
            while (searchIdx < raw.Length) {
                int start = raw.IndexOf(PlaceholderPrefix, searchIdx, StringComparison.Ordinal);
                if (start < 0) break;

                int cursor = start + PlaceholderPrefix.Length;
                int idx = 0, digits = 0;
                while (cursor < raw.Length && char.IsDigit(raw[cursor])) {
                    idx = idx * 10 + (raw[cursor] - '0');
                    digits++; cursor++;
                }

                if (digits == 0 || cursor >= raw.Length ||
                    !raw.AsSpan(cursor).StartsWith(PlaceholderSuffix, StringComparison.Ordinal)) {
                    searchIdx = start + PlaceholderPrefix.Length;
                    continue;
                }

                int end       = cursor + PlaceholderSuffix.Length - 1;
                int startChar = FindCharInfoIndex(info, start);
                int endChar   = FindCharInfoIndex(info, end);

                if (startChar >= 0 && endChar >= 0) {
                    int minLine = info.characterInfo[startChar].lineNumber;
                    int maxLine = info.characterInfo[endChar].lineNumber;
                    if (blocks.TryGetValue(idx, out var existing)) {
                        existing.MinLine = Math.Min(existing.MinLine, minLine);
                        existing.MaxLine = Math.Max(existing.MaxLine, maxLine);
                        blocks[idx] = existing;
                    } else {
                        blocks[idx] = new PlaceholderBlock(minLine, maxLine);
                    }
                }
                searchIdx = end + 1;
            }

            if (info.lineCount == 0) return blocks;

            var keys = new List<int>(blocks.Keys);
            foreach (var key in keys) {
                var b    = blocks[key];
                int minL = Mathf.Clamp(b.MinLine, 0, info.lineCount - 1);
                int maxL = Mathf.Clamp(b.MaxLine, 0, info.lineCount - 1);
                b.Top    = info.lineInfo[minL].ascender;
                b.Bottom = info.lineInfo[maxL].descender;
                blocks[key] = b;
            }

            return blocks;
        }

        private static int FindCharInfoIndex(TMP_TextInfo info, int stringIndex) {
            int count = info.characterCount;
            for (int i = 0; i < count; i++) {
                int ci = info.characterInfo[i].index;
                if (ci == stringIndex) return i;
                if (ci > stringIndex) break;
            }
            return -1;
        }

        private struct PlaceholderBlock {
            public int   MinLine, MaxLine;
            public float Top, Bottom;
            public float Height => Top - Bottom;
            public PlaceholderBlock(int min, int max) {
                MinLine = min; MaxLine = max; Top = 0f; Bottom = 0f;
            }
        }

		[HideFromIl2Cpp]
		public void AddPlaceholder(int index, Sprite placeholderSprite)
		{
			if (_imageRenderers.ContainsKey(index)) return;
			var rend = CreateRenderer(placeholderSprite);
			if (rend != null)
			{
				_imageRenderers[index] = rend;
			}
		}

		[HideFromIl2Cpp]
		public void UpdateImage(int index, Sprite newSprite)
		{
			if (_imageRenderers.TryGetValue(index, out var rend) && rend != null)
			{
				rend.sprite = newSprite;
				LayoutImages();
			}
		}
	}
}
