using UnityEngine;
using TMPro;
using CommonUI.Tutorial.Models;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// テキストボックスのPresenter
    /// </summary>
    public class TextBoxPresenter : MonoBehaviour
    {
        /// <summary>
        /// 反映させるテキストボックス内のTMP
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _textMeshPro;

        /// <summary>
        /// テキストボックスのRectTransform
        /// </summary>
        [SerializeField]
        private RectTransform _textBoxRectTransform;

        /// <summary>
        /// テキストボックスのマスターデータ
        /// </summary>
        [SerializeField]
        private TextBoxMasterData _textData;

        /// <summary>
        /// 現在のtextModelモデルの番号
        /// </summary>
        private int _index = 0;

        private void Start()
        {
            _index = 0;
            SetPosition(_textData.Models[_index].Position);
        }

        private void Update()
        {
            //クリックしたら次のモデルを参照し、SetPositionを実行させる
            if (Input.GetMouseButtonDown(0))
            {
                SetPosition(_textData.Models[++_index].Position);
            }
        }

        /// <summary>
        /// テキストボックスの位置を決める
        /// </summary>
        /// <param name="textPosition">テキストボックスをどこに配置するか指定したもの</param>
        private void SetPosition(TextPositions textPosition)
        {
            // anchorとpivotを調節して,指定した位置に配置させる
            switch (textPosition)
            {
                case TextPositions.TopLeft:
                    _textBoxRectTransform.anchorMax = new Vector2(0, 1);
                    _textBoxRectTransform.anchorMin = new Vector2(0, 1);
                    _textBoxRectTransform.pivot = new Vector2(0, 1);
                    break;
                case TextPositions.TopCenter:
                    _textBoxRectTransform.anchorMax = new Vector2(0.5f, 1);
                    _textBoxRectTransform.anchorMin = new Vector2(0.5f, 1);
                    _textBoxRectTransform.pivot = new Vector2(0.5f, 1);
                    break;
                case TextPositions.TopRight:
                    _textBoxRectTransform.anchorMax = new Vector2(1, 1);
                    _textBoxRectTransform.anchorMin = new Vector2(1, 1);
                    _textBoxRectTransform.pivot = new Vector2(1, 1);
                    break;
                case TextPositions.MiddleLeft:
                    _textBoxRectTransform.anchorMax = new Vector2(0, 0.5f);
                    _textBoxRectTransform.anchorMin = new Vector2(0, 0.5f);
                    _textBoxRectTransform.pivot = new Vector2(0, 0.5f);
                    break;
                case TextPositions.MiddleCenter:
                    _textBoxRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    _textBoxRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    _textBoxRectTransform.pivot = new Vector2(0.5f, 0.5f);
                    break;
                case TextPositions.MiddleRight:
                    _textBoxRectTransform.anchorMax = new Vector2(1, 0.5f);
                    _textBoxRectTransform.anchorMin = new Vector2(1, 0.5f);
                    _textBoxRectTransform.pivot = new Vector2(1, 0.5f);
                    break;
                case TextPositions.BottomLeft:
                    _textBoxRectTransform.anchorMax = Vector2.zero;
                    _textBoxRectTransform.anchorMin = Vector2.zero;
                    _textBoxRectTransform.pivot = Vector2.zero;
                    break;
                case TextPositions.BottomCenter:
                    _textBoxRectTransform.anchorMax = new Vector2(0.5f, 0);
                    _textBoxRectTransform.anchorMin = new Vector2(0.5f, 0);
                    _textBoxRectTransform.pivot = new Vector2(0.5f, 0);
                    break;
                case TextPositions.BottomRight:
                    _textBoxRectTransform.anchorMax = new Vector2(1, 0);
                    _textBoxRectTransform.anchorMin = new Vector2(1, 0);
                    _textBoxRectTransform.pivot = new Vector2(1, 0);
                    break;
                default:
                    Debug.LogError("入力が正しくないです。");
                    break;
            }
        }

    }
}
