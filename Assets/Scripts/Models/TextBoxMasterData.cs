using System.Collections.Generic;
using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    [CreateAssetMenu(fileName = "TextBoxMaster", menuName = "Create Model/TextBoxMasterData", order = 0)]
    public class TextBoxMasterData : ScriptableObject
    {
        /// <summary>
        /// テキストボックスのモデル達
        /// </summary>
        public IReadOnlyList<TextBoxModel> Models => _models;
        [SerializeField]
        private TextBoxModel[] _models;
    }
}