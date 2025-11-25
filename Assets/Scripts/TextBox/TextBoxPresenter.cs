using UnityEngine;
using TMPro;
using CommonUI.Tutorial.Models;

namespace CommonUI.Tutorial
{
    public class TextBoxPresenter : MonoBehaviour
    {
        /// <summary>
        /// 反映させるテキストボックス内のTMP
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _textMeshPro;

        /// <summary>
        /// テキストボックスのマスターデータ
        /// </summary>
        [SerializeField]
        private TextBoxMasterData _textDatas;
    }
}
