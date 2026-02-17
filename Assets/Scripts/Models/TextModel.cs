using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストを設定するためのモデル
    /// </summary>
    [System.Serializable]
    public class TextModel
    {
        [TextArea, SerializeField, Tooltip("表示させるテキスト")]
        private string _text;
        /// <summary>
        /// 表示させるテキスト
        /// </summary>
        public string Text => _text;

        [SerializeField, Tooltip("テキスト表示中に使うコーチマークのモデル")]
        private CoachMarkModel _coachMark;
        /// <summary>
        /// テキスト表示中に使うコーチマークのモデル
        /// </summary>
        public CoachMarkModel CoachMark => _coachMark;

        [SerializeField, Tooltip("テキストボックスを配置する対象のオブジェクトの名前")]
        private string _targetObjectName;
        /// <summary>
        /// テキストボックスを配置する対象のオブジェクトの名前
        /// </summary>
        public string TargetObjectName => _targetObjectName;
    }
}