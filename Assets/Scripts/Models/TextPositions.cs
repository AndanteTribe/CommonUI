using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストボックスの位置
    /// </summary>
    public enum TextPositions : byte
    {
        /// <summary>
        /// 左上
        /// </summary>
        [InspectorName("左上")]
        TopLeft = 1,

        /// <summary>
        /// 中央上
        /// </summary>
        [InspectorName("中央上")]
        TopCenter = 2,

        /// <summary>
        /// 右上
        /// </summary>
        [InspectorName("右上")]
        TopRight = 3,

        /// <summary>
        /// 左中央
        /// </summary>
        [InspectorName("左中央")]
        MiddleLeft = 4,

        /// <summary>
        /// 中央
        /// </summary>
        [InspectorName("中央")]
        MiddleCenter = 0,

        /// <summary>
        /// 右中央
        /// </summary>
        [InspectorName("右中央")]
        MiddleRight = 5,

        /// <summary>
        /// 左下
        /// </summary>
        [InspectorName("左下")]
        BottomLeft = 6,

        /// <summary>
        /// 中心下
        /// </summary>
        [InspectorName("中央下")]
        BottomCenter = 7,

        /// <summary>
        /// 右下
        /// </summary>
        [InspectorName("右下")]
        BottomRight = 8
    }
}