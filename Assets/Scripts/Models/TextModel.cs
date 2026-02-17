using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [System.Serializable, Tooltip("テキストを設定するためのモデル")]
    public class TextModel
    {
        [Tooltip("表示させるテキスト")]
        public string Text => _text;
        [TextArea, SerializeField, Tooltip("表示させるテキスト（内部）")]
        private string _text;

        [Tooltip("テキスト表示中に使うコーチマークのモデル")]
        public CoachMarkModel CoachMark => _coachMark;
        [SerializeField, Tooltip("テキスト表示中に使うコーチマークのモデル（内部）")]
        private CoachMarkModel _coachMark;

        [Tooltip("テキストボックスを配置する対象のオブジェクトの名前")]
        public string TargetObjectName => _targetObjectName;
        [SerializeField, Tooltip("テキストボックスを配置する対象のオブジェクトの名前（内部）")]
        private string _targetObjectName;
    }
}