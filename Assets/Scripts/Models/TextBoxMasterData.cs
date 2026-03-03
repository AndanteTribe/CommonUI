using System.Collections.Generic;
using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// テキストボックスのマスタ―
    /// </summary>
    [CreateAssetMenu(fileName = "TextBoxMaster", menuName = "Create Model/TextBoxMasterData", order = 0)]
    public class TextBoxMasterData : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField, Tooltip("テキストボックスのモデル達")]
        private TextBoxModel[] _models;
        /// <summary>
        /// テキストボックスのモデル達
        /// </summary>
        public IReadOnlyList<TextBoxModel> Models => _models;

#if UNITY_EDITOR
        private int _previousCount;
#endif
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
#if UNITY_EDITOR
            if (_models == null)
            {
                return;
            }

            if (_models.Length > _previousCount)
            {
                _models[^1].ApplyDefaultPos();
            }

            _previousCount = _models.Length;
#endif
        }
    }
}