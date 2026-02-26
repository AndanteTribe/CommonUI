using System.Threading;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    public class ForwardingIcon : MonoBehaviour
    {
        [SerializeField]
        private float _lowestPos = -73.246f;

        [SerializeField]
        private float _highestPos = -77.6f;

        [SerializeField]
        private float _animDuration = 0.3f;

        [SerializeField]
        private RectTransform _rectTransform;

        /// <summary>
        /// ピンのアニメーションを再生する.
        /// </summary>
        /// <param name="cancellationToken">キャンセレーショントークン.</param>
        public async Awaitable PlayAnimAsync(CancellationToken cancellationToken)
        {
            gameObject.SetActive(true);

            await LMotion.Create(_lowestPos, _highestPos, _animDuration)
                .WithLoops(-1, LoopType.Yoyo)
                .WithEase(Ease.Linear)
                .WithOnCancel(() => gameObject.SetActive(false))
                .BindToAnchoredPositionY(_rectTransform)
                .ToAwaitable(cancellationToken);
        }
    }
}