using System.Collections.Generic;
using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストボックスのマスタ―
    /// </summary>
    [CreateAssetMenu(fileName = "TextBoxMaster", menuName = "Create Model/TextBoxMasterData", order = 0)]
    public class TextBoxMasterData : ScriptableObject
    {
        [SerializeField, Tooltip("テキストボックスのモデル達")]
        private TextBoxModel[] _models;
        public IReadOnlyList<TextBoxModel> Models => _models;
    }
}