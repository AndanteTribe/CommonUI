using System.Collections.Generic;
using UnityEngine;
namespace CommonUI.Tutorial.Models
{
    ///<summary>
    /// テキストボックスのモデル
    ///</summary>
    [System.Serializable]
    public class TextBoxModel
    {
        /// <summary>
        /// 大まかな位置を指定させる
        /// </summary>
        public TextPositions Position => _position;
        [SerializeField]
        private TextPositions _position;

        /// <summary>
        /// 垂直方向に対してどれくらいずらすか
        /// </summary>
        public ValueKinds RadiusVerticalPos => _radiusVerticalPos;
        [SerializeField]
        private ValueKinds _radiusVerticalPos;

        /// <summary>
        /// 水平方向に対してどれくらいずらすか
        /// </summary>
        public ValueKinds RadiusHorizontalPos => _radiusHorizontalPos;
        [SerializeField]
        private ValueKinds _radiusHorizontalPos;

        /// <summary>
        /// 表示するテキストモデルの一覧
        /// </summary>
        public IReadOnlyList<TextModel> Models => _models;
        [SerializeField]
        private TextModel[] _models;
    }
}