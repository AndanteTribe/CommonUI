using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [Tooltip("テキストボックスの位置")]
    public enum TextPositions : byte
    {
        [Tooltip("左上")]
        [InspectorName("左上")]
        TopLeft,

        [Tooltip("中央上")]
        [InspectorName("中央上")]
        TopCenter,

        [Tooltip("右上")]
        [InspectorName("右上")]
        TopRight,

        [Tooltip("左中央")]
        [InspectorName("左中央")]
        MiddleLeft,


        [Tooltip("中央")]
        [InspectorName("中央")]
        MiddleCenter,

        [Tooltip("右中央")]
        [InspectorName("右中央")]
        MiddleRight,

        [Tooltip("左下")]
        [InspectorName("左下")]
        BottomLeft,

        [Tooltip("中心下")]
        [InspectorName("中央下")]
        BottomCenter,

        [Tooltip("右下")]
        [InspectorName("右下")]
        BottomRight
    }
}