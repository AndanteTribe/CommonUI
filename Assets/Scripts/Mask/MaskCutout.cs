using Coffee.UISoftMask;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// SoftMaskの処理をラップして，コーチマークのマスクくり抜きを行うクラス
    /// </summary>
    public class MaskCutout : MonoBehaviour
    {
        [SerializeField, Tooltip("四角形のマスクくり抜き用のスプライト")]
        private Sprite _submaskRectangleSprite;

        [SerializeField, Tooltip("円形のマスクくり抜き用のスプライト")]
        private Sprite _submaskCircleSprite;

        [SerializeField, Tooltip("SubtractオブジェクトのRectTransform")]
        private RectTransform _subtractRectTransform;

        [SerializeField, Tooltip("SubtractオブジェクトのImage")]
        private Image _subtractImage;

        [SerializeField, Tooltip("SubtractオブジェクトのMaskingShape")]
        private MaskingShape _subtractMaskingShape;

        /// <summary> 0に丸め込まれない小さな正の値 </summary>
        private const float FloatMinNormal = 1e-7f;

        /// <summary>
        /// 四角形にマスクをくり抜く処理
        /// </summary>
        /// <param name="centerX">くり抜きの中心X座標</param>
        /// <param name="centerY">くり抜きの中心Y座標</param>
        /// <param name="width">くり抜きの横幅</param>
        /// <param name="height">くり抜きの縦幅</param>
        /// <param name="paddingRatio">
        ///     くり抜き部分からのパディング[0～1]
        ///     paddingRatioとgradientRatioの合計値が1以下になるようにクランプされます。（paddingRatio優先）
        /// </param>
        /// <param name="gradientRatio">
        ///     グラデーションの幅 [0～1]
        ///     paddingRatioとgradientRatioの合計値が1以下になるようにクランプされます。
        /// </param>
        public void SetRectangle(float centerX, float centerY, float width, float height,
            float paddingRatio, float gradientRatio)
        {
            width  = Mathf.Max(width, 0);
            height = Mathf.Max(height, 0);
            ClampSoftnessParams(ref paddingRatio, ref gradientRatio);

            _subtractImage.sprite = _submaskRectangleSprite;

            (width, height) = CalculateCenterSize(_subtractImage, width, height);
            SetupRectTransform(centerX, centerY, width, height);
            ApplySoftnessRange(paddingRatio, gradientRatio);
        }

        /// <summary>
        /// 円形にマスクをくり抜く処理
        /// </summary>
        /// <param name="centerX">くり抜きの中心X座標</param>
        /// <param name="centerY">くり抜きの中心Y座標</param>
        /// <param name="diameter">くり抜きの直径</param>
        /// <param name="paddingRatio">
        ///     くり抜き部分からのパディング[0～1]
        ///     paddingRatioとgradientRatioの合計値が1以下になるようにクランプされます。（paddingRatio優先）
        /// </param>
        /// <param name="gradientRatio">
        ///     グラデーションの幅 [0～1]
        ///     paddingRatioとgradientRatioの合計値が1以下になるようにクランプされます。
        /// </param>
        public void SetCircle(float centerX, float centerY, float diameter,
            float paddingRatio, float gradientRatio)
        {
            diameter = Mathf.Max(diameter, 0);
            ClampSoftnessParams(ref paddingRatio, ref gradientRatio);

            _subtractImage.sprite = _submaskCircleSprite;

            SetupRectTransform(centerX, centerY, diameter * 2f, diameter * 2f);
            ApplySoftnessRange(paddingRatio, gradientRatio);
        }

        /// <summary>
        /// RectTransformへの設定値適用処理
        /// </summary>
        private void SetupRectTransform(float centerX, float centerY, float rectWidth, float rectHeight)
        {
            // アンカーとピボットは中心(0.5, 0.5)固定
            var center = new Vector2(0.5f, 0.5f);
            _subtractRectTransform.anchorMin = center;
            _subtractRectTransform.anchorMax = center;
            _subtractRectTransform.pivot     = center;

            _subtractRectTransform.anchoredPosition = new Vector2(centerX, centerY);

            _subtractRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectWidth);
            _subtractRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,   rectHeight);
        }

        /// <summary>
        /// paddingRatio と gradientRatio から softnessRange を計算して適用する処理
        /// </summary>
        private void ApplySoftnessRange(float paddingRatio, float gradientRatio)
        {
            // paddingRatio と gradientRatio の合計が1を超えないようにクランプする
            paddingRatio = Mathf.Clamp01(paddingRatio);
            var gradientMax = 1f - paddingRatio;
            if (gradientRatio > gradientMax)
            {
                Debug.LogWarning(
                    $"[MaskCutout] paddingRatio({paddingRatio:F3}) + gradientRatio({gradientRatio:F3}) が 1 を超えています。" +
                    $"gradientRatio を {gradientMax:F3} にクランプしました。");
                gradientRatio = gradientMax;
            }

            var softMax = 1f - paddingRatio;
            var softMin = 1f - paddingRatio - gradientRatio;

            _subtractMaskingShape.softnessRange = new MinMax01(softMin, softMax);
        }

        /// <summary>
        /// ソフトマスクのパラメータのクランプ処理
        /// </summary>
        private static void ClampSoftnessParams(ref float paddingRatio, ref float gradientRatio)
        {
            paddingRatio  = Mathf.Max(paddingRatio, 0);
            gradientRatio = Mathf.Max(gradientRatio, 0);
            if (paddingRatio + gradientRatio <= 0f)
            {
                paddingRatio = FloatMinNormal;  // 合計値が0の場合はくり抜きが表示されないため最小値でクランプ
            }
        }

        /// <summary>
        /// Sliced Imageの「中央(ストレッチ領域)」が指定サイズになるようにRectTransformのサイズを計算する処理
        /// </summary>
        private static (float width, float height) CalculateCenterSize(Image slicedImage, float centerWidth, float centerHeight)
        {
            var border = slicedImage.sprite.border / slicedImage.pixelsPerUnit;

            // 中央サイズ + 枠サイズ = 全体サイズ
            return (centerWidth  + border.x + border.z,
                    centerHeight + border.y + border.w);
        }
    }
}
