using System.Collections.Generic;
using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストボックスのモデル
    /// </summary>
    [System.Serializable]
    public class TextBoxModel
    {
        [SerializeField, Tooltip("大まかな位置")]
        private TextPositions _position;
        /// <summary>
        /// 大まかな位置
        /// </summary>
        public TextPositions Position => _position;

        [SerializeField, Tooltip("垂直方向に対してどれくらいずらすか")]
        private ValueKinds _radiusVerticalOffset;
        /// <summary>
        /// 垂直方向に対してどれくらいずらすか
        /// </summary>
        public ValueKinds RadiusVerticalOffset => _radiusVerticalOffset;

        [SerializeField, Tooltip("水平方向に対してどれくらいずらすか")]
        private ValueKinds _radiusHorizontalOffset;
        /// <summary>
        /// 水平方向に対してどれくらいずらすか
        /// </summary>
        public ValueKinds RadiusHorizontalOffset => _radiusHorizontalOffset;

        [SerializeField, Tooltip("表示するテキストモデルの一覧")]
        private TextModel[] _models;
        /// <summary>
        /// 表示するテキストモデルの一覧
        /// </summary>
        public IReadOnlyList<TextModel> Models => _models;

#if UNITY_EDITOR
        /// <summary>
        /// inspector上で新しく追加されたmodelのpositionを上書きするためのメソッド.
        /// </summary>
        internal void ApplyDefaultPos() => _position = TextPositions.MiddleCenter;
#endif
    }
}