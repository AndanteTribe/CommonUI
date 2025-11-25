using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストボックスの位置
    /// </summary>
    public enum TextPositions : byte
    {
        [InspectorName("左上")]
        TopLeft,
        [InspectorName("中央上")]
        TopCenter,
        [InspectorName("右上")]
        TopRight,
        [InspectorName("左中央")]
        MiddleLeft,
        [InspectorName("中央")]
        MiddleCenter,
        [InspectorName("右中央")]
        MiddleRight,
        [InspectorName("左下")]
        BottomLeft,
        [InspectorName("中央下")]
        BottomCenter,
        [InspectorName("右下")]
        BottomRight
    }
}