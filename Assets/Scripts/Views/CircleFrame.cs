using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    [System.Serializable]
    public class CircleFrame : Frame
    {
        [SerializeField, Tooltip("自身のRectTransform")]
        private RectTransform _rectTransform;

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
            // ParticleEffectで行っているため、コーチマークの座標を取得した後、
            // OverlayCanvasに置かれているエフェクトを調節する。

            // コーチマークのワールド座標を取得する。
            coachMarkPos.GetWorldCorners(_worldCorners);

            // ワールド座標に当てはめる。
            _rectTransform.position = (_worldCorners[0] + _worldCorners[2]) / 2;
        }

        /// <summary>
        /// コーチマークのサイズに合わせる。
        /// </summary>
        /// <param name="coachMarkPos">コーチマークの座標</param>
        public override void SetSize(RectTransform coachMarkPos)
        {
            // フレームの大きさを設定する。
            // 円形の場合、ParticleEffectで作成されているので、コーチマークの大きさに合わせてscaleを変更する。
            var width = coachMarkPos.rect.width;
            var height = coachMarkPos.rect.height;

            // デカイ方を半径とする。
            var radius = Mathf.Max(width, height);

            // 半径に合わせてアニメーションフレームの大きさを設定する。
            var scale = radius / AnimatedSize;
            _rectTransform.localScale = new Vector3(scale, scale, 1);
        }
    }
}