using System.Threading;
using LitMotion;
using LitMotion.Extensions;
using TMPro;
using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    /// <summary>
    /// <see cref="TextMeshProUGUI"/>に文字送りの拡張を提供するクラス.
    /// </summary>
    public static class TextAnimationExtention
    {
        /// <summary>
        /// 文字送りさせるメソッド.
        /// </summary>
        /// <param name="tmp">文字送りさせる対象.</param>
        /// <param name="text">文字送りさせたいテキスト.</param>
        /// <param name="speed">表示にかかる1文字あたりの時間.</param>
        /// <param name="token">キャンセルトークン.</param>
        public static async Awaitable Animate(this TextMeshProUGUI tmp, string text, float speed, CancellationToken token)
        {
            tmp.text = text;
            tmp.maxVisibleCharacters = 0;

            await LMotion.Create(0, text.Length, text.Length * speed)
                .WithEase(Ease.Linear)
                .BindToMaxVisibleCharacters(tmp)
                .ToAwaitable(CancelBehavior.Complete, token);
        }
    }
}