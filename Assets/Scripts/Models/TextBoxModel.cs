using System.Collections.Generic;
using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [System.Serializable, Tooltip("テキストボックスのモデル")]
    public class TextBoxModel
    {
        [Tooltip("大まかな位置を指定させる")]
        public TextPositions Position => _position;
        [SerializeField, Tooltip("大まかな位置（内部）")]
        private TextPositions _position;

        [Tooltip("垂直方向に対してどれくらいずらすか")]
        public ValueKinds RadiusVerticalOffset => _radiusVerticalOffset;
        [SerializeField, Tooltip("垂直方向に対してどれくらいずらすか（内部）")]
        private ValueKinds _radiusVerticalOffset;

        [Tooltip("水平方向に対してどれくらいずらすか")]
        public ValueKinds RadiusHorizontalOffset => _radiusHorizontalOffset;
        [SerializeField, Tooltip("水平方向に対してどれくらいずらすか（内部）")]
        private ValueKinds _radiusHorizontalOffset;

        [Tooltip("表示するテキストモデルの一覧")]
        public IReadOnlyList<TextModel> Models => _models;
        [SerializeField, Tooltip("表示するテキストモデルの一覧（内部）")]
        private TextModel[] _models;
    }
}