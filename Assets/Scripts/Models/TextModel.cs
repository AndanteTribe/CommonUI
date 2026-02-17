using UnityEngine;
using CommonUI.Tutorial;

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
        public string Text => _text;

        [SerializeField, Tooltip("テキスト表示中に使うコーチマークのモデル")]
        private CoachMarkModel _coachMark;
        public CoachMarkModel CoachMark => _coachMark;

        [SerializeField, Tooltip("テキストボックスを配置する対象のオブジェクトの名前")]
        private string _targetObjectName;
        public string TargetObjectName => _targetObjectName;
    }
}