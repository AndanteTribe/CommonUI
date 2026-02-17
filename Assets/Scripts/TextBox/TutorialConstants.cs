using UnityEngine;

namespace CommonUI.Tutorial
{
    public static class TutorialConstants
    {
        public static class TextBoxPositions
        {
            [Tooltip("左上に配置するためのベクトル")]
            public static readonly Vector2 TopLeftVector = new Vector2(0, 1);

            [Tooltip("中央上に配置するためのベクトル")]
            public static readonly Vector2 TopCenterVector = new Vector2(0.5f, 1);

            [Tooltip("右上に配置するためのベクトル")]
            public static readonly Vector2 TopRightVector = new Vector2(1, 1);

            [Tooltip("中央左に配置するためのベクトル")]
            public static readonly Vector2 MiddleLeftVector = new Vector2(0, 0.5f);

            [Tooltip("中央に配置するためのベクトル")]
            public static readonly Vector2 MiddleCenterVector = new Vector2(0.5f, 0.5f);

            [Tooltip("中央右に配置するためのベクトル")]
            public static readonly Vector2 MiddleRightVector = new Vector2(1, 0.5f);

            [Tooltip("左下に配置するためのベクトル")]
            public static readonly Vector2 BottomLeftVector = new Vector2(0, 0);

            [Tooltip("中央下に配置するためのベクトル")]
            public static readonly Vector2 BottomCenterVector = new Vector2(0.5f, 0);

            [Tooltip("右下に配置するためのベクトル")]
            public static readonly Vector2 BottomRightVector = new Vector2(1, 0);
        }
    }
}