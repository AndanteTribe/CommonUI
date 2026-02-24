using System;
using System.Threading;
using AndanteTribe.Utils.Unity;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace CommonUI.Tutorial.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class PageDot : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private RectTransform _outlineRect;

        [SerializeField]
        private RectTransform _insideCircleRect;

        [SerializeField]
        private Image _insideCircle;

        [SerializeField]
        private float durationSec = 1;

        [SerializeField]
        private VisualState[] _allStates;

        private int _currentStateIndex;

        public PageDot NextDot { get; set; }
        public PageDot PrevDot { get; set; }

        /// <summary>
        /// PageDotを前のステートに進ませる.
        /// </summary>
        /// <param name="cancellationToken">キャンセレーショントークン.</param>
        public async Awaitable NextAsync(CancellationToken cancellationToken)
        {
            if (_currentStateIndex < _allStates.Length - 1)
            {
                _currentStateIndex++;
                await AnimateAsync(_currentStateIndex, cancellationToken);
            }
        }

        /// <summary>
        /// PageDotを次のステートに進ませる.
        /// </summary>
        /// <param name="cancellationToken">キャンセレーショントークン.</param>
        public async Awaitable PrevAsync(CancellationToken cancellationToken)
        {
            if (_currentStateIndex > 0)
            {
                _currentStateIndex--;
                await AnimateAsync(_currentStateIndex, cancellationToken);
            }
        }

        /// <summary>
        /// PageDotを指定のステートに移動させる.
        /// </summary>
        /// <param name="stateIndex">指定のステート.</param>
        public void SetState(int stateIndex)
        {
            _rectTransform.anchoredPosition = new Vector2(_allStates[stateIndex].posX, _rectTransform.anchoredPosition.y);
            _insideCircle.color = _allStates[stateIndex].color;
            _insideCircleRect.SetWidth(_allStates[stateIndex].insideCircleSize);
            _insideCircleRect.SetHeight(_allStates[stateIndex].insideCircleSize);
            _outlineRect.SetWidth(_allStates[stateIndex].outlineSize);
            _outlineRect.SetHeight(_allStates[stateIndex].outlineSize);
            _currentStateIndex = stateIndex;
        }

        private async Awaitable AnimateAsync(int targetIndex, CancellationToken cancellationToken)
        {
            var currentX = _rectTransform.anchoredPosition.x;
            var targetX = _allStates[targetIndex].posX;

            var currentColor = _insideCircle.color;
            var targetColor = _allStates[targetIndex].color;

            var currentInsideCircle = new Vector2(_insideCircleRect.rect.width,  _insideCircleRect.rect.height);
            var targetInsideCircle = new Vector2(_allStates[targetIndex].insideCircleSize, _allStates[targetIndex].insideCircleSize);

            var currentOutline = new Vector2(_outlineRect.rect.width, _outlineRect.rect.height);
            var targetOutline = new Vector2(_allStates[targetIndex].outlineSize, _allStates[targetIndex].outlineSize);

            var posAnim = LMotion.Create(currentX, targetX, durationSec)
                .WithEase(Ease.Linear)
                .BindToAnchoredPositionX(_rectTransform)
                .ToAwaitable(cancellationToken);

            var colorAnim = LMotion.Create(currentColor, targetColor, durationSec)
                .WithEase(Ease.Linear)
                .BindToColor(_insideCircle)
                .ToAwaitable(cancellationToken);

            var widthAnim = LMotion.Create(currentInsideCircle, targetInsideCircle, durationSec)
                .WithEase(Ease.Linear)
                .Bind(_insideCircleRect, static (v, target) =>
                {
                    target.SetWidth(v.x);
                    target.SetHeight(v.y);
                })
                .ToAwaitable(cancellationToken);

            var heightAnim = LMotion.Create(currentOutline, targetOutline, durationSec)
                .WithEase(Ease.Linear)
                .Bind(_outlineRect, static (v, target) =>
                {
                    target.SetHeight(v.x);
                    target.SetWidth(v.y);
                })
                .ToAwaitable(cancellationToken);

            await posAnim;
            await colorAnim;
            await widthAnim;
            await heightAnim;
        }

        [Serializable]
        private struct VisualState
        {
            public float posX;
            public Color32 color;
            public float insideCircleSize;
            public float outlineSize;
        }
    }
}