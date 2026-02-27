using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    [System.Serializable]
    public class RectangleFrame : Frame
    {
        [SerializeField, Tooltip("自身のRectTransform")]
        private RectTransform _rectTransform;

        [SerializeField, Tooltip("ずっと表示されるフレームの座標")]
        private RectTransform _baseTransform;

        [SerializeField, Tooltip("アニメーションのあるフレームの座標")]
        private RectTransform _animatedRectTransform;

        /// <summary>
        /// アニメーションフレームの大きさの初期値(横)
        /// </summary>
        private const float AnimatedWidth = 300;

        /// <summary>
        /// アニメーションフレームの大きさの初期値(縦)
        /// </summary>
        private const float AnimatedHeight = 100;

        public void SetFrame(RectTransform coachMarkPos)
        {
            SetPosition(coachMarkPos);
            SetSize(coachMarkPos);
        }

        /// <summary>
        /// コーチマークの座標に合わせる。
        /// </summary>
        /// <param name="coachMarkPos">コーチマークの座標</param>
        public override void SetPosition(RectTransform coachMarkPos)
        {
            _rectTransform.position = coachMarkPos.position;
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

            // アニメーションフレームの大きさを設定する。
            // アニメーション内でsizeDeltaは使用されているため、scaleを変更することで大きさを合わせる。
            var scaleX = width / AnimatedWidth;
            var scaleY = height / AnimatedHeight;
            _animatedRectTransform.localScale = new Vector3(scaleX, scaleY, 1);
        }
    }
}