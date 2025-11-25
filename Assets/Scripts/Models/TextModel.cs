using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストを設定するためのモデル
    /// </summary>
    [System.Serializable]
    public class TextModel
    {
        /// <summary>
        /// 表示させるテキスト
        /// </summary>
        public string Text => _text;
        [TextArea, SerializeField]
        private string _text;

        /// <summary>
        /// テキスト表示中に使うコーチマークのモデル
        /// </summary>
        public CoachMarkModel CoachMark => _coachMark;
        [SerializeField]
        private CoachMarkModel _coachMark;

        /// <summary>
        /// テキストボックスを配置する対象のオブジェクトの名前
        /// </summary>
        public string TargetObjectName => _targetObjectName;
        [SerializeField]
        private string _targetObjectName;
    }
}