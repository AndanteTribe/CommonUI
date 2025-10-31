using System;
using System.Buffers;
using UnityEditor;
using UnityEngine;

namespace AndanteTribe.CommonUI.Editor
{
    public static class DesignUtils
    {
        [MenuItem("GameObject/Rect計算", false, 0)]
        private static void RectSizeCalculate(MenuCommand command)
        {
            var corners = ArrayPool<Vector3>.Shared.Rent(4);

            try
            {
                var canvas = default(Canvas);
                var rect = Rect.zero;

                foreach (var gameObject in Selection.gameObjects)
                {
                    if (gameObject.transform is RectTransform rectTransform)
                    {
                        if (canvas == null)
                        {
                            canvas = rectTransform.GetComponentInParent<Canvas>();
                        }

                        rectTransform.GetWorldCorners(corners);

                        foreach (var edge in corners.AsSpan(0, 4))
                        {
                            var local = canvas.transform.InverseTransformPoint(edge);
                            if (rect == Rect.zero)
                            {
                                rect = new Rect(local, Vector2.zero);
                            }
                            else
                            {
                                rect.xMin = Math.Min(rect.xMin, local.x);
                                rect.yMin = Math.Min(rect.yMin, local.y);
                                rect.xMax = Math.Max(rect.xMax, local.x);
                                rect.yMax = Math.Max(rect.yMax, local.y);
                            }
                        }
                    }
                }

                if (canvas != null && rect != Rect.zero)
                {
                    Debug.Log("Rect計算結果: Size=" + rect.size.ToString());
                }
                else
                {
                    Debug.LogWarning("RectTransformが選択されていないか、計算できる要素がありませんでした。");
                }
            }
            finally
            {
                ArrayPool<Vector3>.Shared.Return(corners);
            }
        }

        [MenuItem("GameObject/Rect計算", true)]
        private static bool ValidateRectSizeCalculate()
        {
            // 1つ以上選択されているときだけメニューを表示
            return Selection.gameObjects != null && Selection.gameObjects.Length > 0;
        }
    }
}