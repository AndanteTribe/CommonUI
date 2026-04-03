using UnityEngine;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine.UI;

namespace CommonUI.Tutorial.Views
{
    public class RectangleFrame : Frame
    {
        [SerializeField, Tooltip("ずっと表示されるフレームの座標")]
        private RectTransform _baseTransform;

        [SerializeField, Tooltip("アニメーションのあるフレームの座標")]
        private RectTransform _animatedRectTransform;

        [SerializeField, Tooltip("アニメーションフレームのImageコンポーネント")]
        private Image _animatedImage;

        /// <summary>
        /// モーションに使用する時間
        /// </summary>
        private const float AnimatedTime = 1f;

        /// <summary>
        /// アニメーションフレームの大きさをどれくらい大きくするかの倍率
        /// </summary>
        private const float AnimatedMultiplier = 1.3f;

        /// <summary>
        /// 動きのあるフレームのモーションハンドル(width)
        /// </summary>
        private MotionHandle _animatedWidthMotionHandle;

        /// <summary>
        /// 動きのあるフレームのモーションハンドル(height)
        /// </summary>
        private MotionHandle _animatedHeightMotionHandle;

        /// <summary>
        /// 透過アニメーションのモーションハンドル
        /// </summary>
        private MotionHandle _animatedAlphaMotionHandle;

        /// <summary>
        /// コーチマークの座標に合わせる。
        /// </summary>
        /// <param name="coachMarkPos">コーチマークの座標</param>
        public override void SetPosition(RectTransform coachMarkPos)
        {
            RectTransform.position = coachMarkPos.position;
        }

        /// <summary>
        /// コーチマークのサイズに合わせる。
        /// </summary>
        /// <param name="coachMarkPos"></param>
        public override void SetSize(RectTransform coachMarkPos)
        {
            // コーチマークのサイズを取得する。
            var width = coachMarkPos.sizeDelta.x;
            var height = coachMarkPos.sizeDelta.y;

            // ベースフレームの大きさを設定する。
            _baseTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            _baseTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        /// <summary>
        /// アニメーションフレームの用意をする
        /// </summary>
        /// <param name="coachMarkPos"></param>
        public void SetAnimation(RectTransform coachMarkPos)
        {
            var width = coachMarkPos.sizeDelta.x;
            var height = coachMarkPos.sizeDelta.y;

            // アニメーションフレームの大きさを設定する。
            // 以下、透過アニメーションを持つフレームについて扱う
            // モーション再生中ならばキャンセルし、新たなモーションを作成する。
            if (_animatedWidthMotionHandle.IsActive())
            {
                _animatedWidthMotionHandle.Cancel();
            }

            // モーションを作成する
            // アニメーションフレームの大きさを設定する。
            _animatedWidthMotionHandle = LMotion.Create(width, width * AnimatedMultiplier, AnimatedTime)
                .WithEase(Ease.OutQuad)
                .WithLoops(-1, LoopType.Restart)
                .BindToSizeDeltaX(_animatedRectTransform);

            // 同様に高さのモーションも作成する。
            if(_animatedHeightMotionHandle.IsActive())
            {
                _animatedHeightMotionHandle.Cancel();
            }

            _animatedHeightMotionHandle = LMotion.Create(height, height * AnimatedMultiplier, AnimatedTime)
                .WithEase(Ease.OutQuad)
                .WithLoops(-1, LoopType.Restart)
                .BindToSizeDeltaY(_animatedRectTransform);

            // 透過アニメーションも同様に実装する
            if(_animatedAlphaMotionHandle.IsActive())
            {
                _animatedAlphaMotionHandle.Cancel();
            }
            _animatedAlphaMotionHandle = LMotion.Create(1f, 0f, AnimatedTime)
                .WithEase(Ease.OutQuad)
                .WithLoops(-1, LoopType.Restart)
                .BindToColorA(_animatedImage);
        }

        /// <summary>
        /// 非表示になった際にモーションをキャンセルする
        /// </summary>
        public void OnDisable()
        {
            // モーションが再生されている場合はキャンセルする。
            if (_animatedWidthMotionHandle.IsActive())
            {
                _animatedWidthMotionHandle.Cancel();
            }
            if (_animatedHeightMotionHandle.IsActive())
            {
                _animatedHeightMotionHandle.Cancel();
            }

            if (_animatedAlphaMotionHandle.IsActive())
            {
                _animatedAlphaMotionHandle.Cancel();
            }
        }
    }
}