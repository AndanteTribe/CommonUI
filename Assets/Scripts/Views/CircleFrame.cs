using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    public class CircleFrame : Frame
    {

        [SerializeField, Tooltip("ずっと表示されるフレームの座標")]
        private RectTransform _baseTransform;

        [SerializeField, Tooltip("アニメーションのあるフレームの座標")]
        private RectTransform _animatedRectTransform;

        /// <summary>
        /// アニメーションフレームの大きさの初期値
        /// </summary>
        private const float AnimatedSize = 100;

        /// <summary>
        /// UIの位置を取得しておくフィールド
        /// </summary>
        private readonly Vector3[] _worldCorners = new Vector3[4];

        /// <summary>
        /// コーチマークの座標に合わせる。
        /// </summary>
        /// <param name="coachMarkPos">コーチマークの座標</param>
        public override void SetPosition(RectTransform coachMarkPos)
        {
            // コーチマークのワールド座標を取得する。
            coachMarkPos.GetWorldCorners(_worldCorners);

            // ワールド座標に当てはめる。
            RectTransform.position = (_worldCorners[0] + _worldCorners[2]) / 2;
        }

        /// <summary>
        /// コーチマークのサイズに合わせる。
        /// </summary>
        /// <param name="coachMarkPos">コーチマークの座標</param>
        public override void SetSize(RectTransform coachMarkPos)
        {
            // フレームの大きさを設定する。
            var width = coachMarkPos.rect.width;
            var height = coachMarkPos.rect.height;

            // デカイ方を半径とする。
            var radius = Mathf.Max(width, height);

            // ベースフレームの大きさを設定する。
            _baseTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, radius);
            _baseTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, radius);

            // アニメーションフレームの大きさを設定する。
            // アニメーション内でsizeDeltaは使用されているため、scaleを変更することで大きさを合わせる。
            var scale = radius / AnimatedSize;
            _animatedRectTransform.localScale = new Vector3(scale, scale, 1);
        }
    }
}