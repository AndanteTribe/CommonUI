using System.Collections.Generic;
using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [CreateAssetMenu(fileName = "TextBoxMaster", menuName = "Create Model/TextBoxMasterData", order = 0),
     Tooltip("テキストボックスのマスタ―")]
    public class TextBoxMasterData : ScriptableObject
    {
        [Tooltip("テキストボックスのモデル達")]
        public IReadOnlyList<TextBoxModel> Models => _models;
        [SerializeField, Tooltip("テキストボックスのモデル達（内部）")]
        private TextBoxModel[] _models;
    }
}