using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// コーチマークの形を設定する列挙型
    /// </summary>
    public enum ShapeKinds : byte
    {
        /// <summary>
        /// 長方形
        /// </summary>
        [InspectorName("長方形")]
        Rectangle,

        /// <summary>
        /// 円形
        /// </summary>
        [InspectorName("円形")]
        Circle,

        /// <summary>
        /// グラデーションありの矩形
        /// </summary>
        [InspectorName("グラデーション長方形")]
        GradiateRectangle,

        /// <summary>
        /// グラデーションありの円形
        /// </summary>
        [InspectorName("グラデーション円形")]
        GradiateCircle
    }
}