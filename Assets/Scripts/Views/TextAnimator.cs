using LitMotion;
using TMPro;
using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    /// <summary>
    /// テキストを一文字ずつ表示させる.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextAnimator : MonoBehaviour
    {
        /// <summary>
        /// 文字送りの速さ.
        /// </summary>
        [SerializeField, Tooltip("文字送りの速さ")]
        private float _textSpeed = 0.1f;

        /// <summary>
        /// 文字送り中かどうか.
        /// </summary>
        public bool IsAnimating => _handle.IsActive();

        private MotionHandle _handle;
        private TextMeshProUGUI _textMeshPro;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _textMeshPro.text = "";
        }

        /// <summary>
        /// テキストの表示を開始
        /// </summary>
        /// <param name="text">表示するテキスト</param>
        public void Show(string text)
        {
            if (_handle.IsActive())
            {
                _handle.Cancel();
            }

            _textMeshPro.text = text;
            _textMeshPro.maxVisibleCharacters = 0;

            _handle = LMotion.Create(0, text.Length, text.Length * _textSpeed)
                .WithEase(Ease.Linear)
                .Bind(_textMeshPro, (x, target) => target.maxVisibleCharacters = x)
                .AddTo(gameObject);
        }

        /// <summary>
        /// 文字送り中のテキストを即座にすべて表示する.
        /// </summary>
        public void SkipAnimation()
        {
            if (_handle.IsActive())
            {
                _handle.Complete();
            }
        }
    }
}