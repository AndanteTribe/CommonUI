using System.Collections.Generic;
using UnityEngine;
using CommonUI.Tutorial;

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
        public TextPositions Position => _position;

        [SerializeField, Tooltip("垂直方向に対してどれくらいずらすか")]
        private ValueKinds _radiusVerticalOffset;
        public ValueKinds RadiusVerticalOffset => _radiusVerticalOffset;

        [SerializeField, Tooltip("水平方向に対してどれくらいずらすか")]
        private ValueKinds _radiusHorizontalOffset;
        public ValueKinds RadiusHorizontalOffset => _radiusHorizontalOffset;

        [SerializeField, Tooltip("表示するテキストモデルの一覧")]
        private TextModel[] _models;
        public IReadOnlyList<TextModel> Models => _models;
    }
}