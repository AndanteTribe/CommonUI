using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using CommonUI.Tutorial.Models;
using CommonUI.Tutorial.Views;
using UnityEngine.Pool;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// テキストボックスのPresenter
    /// </summary>
    public class TextBoxPresenter : MonoBehaviour
    {
        [SerializeField, Tooltip("反映させるテキストボックス内のTMP")]
        private TextMeshProUGUI _textMeshPro;

        [SerializeField, Tooltip("テキストボックスのRectTransform")]
        private RectTransform _textBoxRectTransform;

        [SerializeField, Tooltip("テキストボックスのマスターデータ")]
        private TextBoxMasterData _textData;

        /// <summary>
        /// 現在のtextModelモデルの番号
        /// </summary>
        private int _modelIndex = 0;

        [SerializeField]
        private float _textAnimDurationSec = 0.1f;

        [SerializeField]
        private bool _isPinEnabled = true;

        [SerializeField]
        private ForwardingIcon _forwardingIcon;

        [SerializeField]
        private SkipButton _skipButton;

        [SerializeField]
        private PageDotPresenter _pageDotPresenter;

        private int _totalPages;
        private int _pageIndex;

        private CancellationTokenSource _cts;

        private bool _isTextAnimating;

        private void Start()
        {
            _cts = new CancellationTokenSource();

            // スキップボタンの登録
            _skipButton.OnSkip += OnSkip;

            _modelIndex = 0;
            LoadModel(_modelIndex);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 文字送り中にクリックされた場合は全文表示
                if (_isTextAnimating)
                {
                    _cts.Cancel();
                }
                else
                {
                    // 次のページを表示する.
                    if (_pageIndex < _totalPages - 1)
                    {
                        _pageIndex++;
                        ResetToken();
                        _ = ShowPage(_pageIndex);

                        _pageDotPresenter.Next();
                    }
                    //
                    else if (_modelIndex < _textData.Models.Count - 1)
                    {
                        _modelIndex++;
                        LoadModel(_modelIndex);
                    }
                }
            }
            // 戻るボタンで前のページ表示
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_pageIndex <= 0)
                {
                    return;
                }
                _pageIndex--;
                _ = ShowPage(_pageIndex);
                _pageDotPresenter.Prev();
            }
        }

        /// <summary>
        /// <see cref="modelIndex"/>番目のモデルを読み込む.
        /// </summary>
        /// <param name="modelIndex">モデルの番号</param>
        private void LoadModel(int modelIndex)
        {
            var modelData = _textData.Models[modelIndex];
            _totalPages = modelData.Models.Count;

            _pageDotPresenter.Initialize(_totalPages);

            SetPosition(modelData.Position);

            _pageIndex = 0;

            _ = ShowPage(_pageIndex);
        }

        private async Awaitable ShowPage(int pageIndex)
        {
            var text = _textData.Models[_modelIndex].Models[pageIndex].Text;
            _isTextAnimating = true;
            try
            {
                ResetToken();
                await _textMeshPro.AnimateTextAsync(text, TimeSpan.FromSeconds(_textAnimDurationSec), _cts.Token);
            }
            finally
            {
                _isTextAnimating = false;
                if (_isPinEnabled)
                {
                    ResetToken();
                    _ = _forwardingIcon.PlayAnimAsync(_cts.Token);
                }
            }
        }

        private void OnSkip()
        {
            _modelIndex++;
            LoadModel(_modelIndex);
        }

        private void ResetToken()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts =  new CancellationTokenSource();
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
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.TopLeftVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.TopLeftVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.TopLeftVector;
                    break;
                case TextPositions.TopCenter:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.TopCenterVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.TopCenterVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.TopCenterVector;
                    break;
                case TextPositions.TopRight:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.TopRightVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.TopRightVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.TopRightVector;
                    break;
                case TextPositions.MiddleLeft:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.MiddleLeftVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.MiddleLeftVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.MiddleLeftVector;
                    break;
                case TextPositions.MiddleCenter:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.MiddleCenterVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.MiddleCenterVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.MiddleCenterVector;
                    break;
                case TextPositions.MiddleRight:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.MiddleRightVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.MiddleRightVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.MiddleRightVector;
                    break;
                case TextPositions.BottomLeft:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.BottomLeftVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.BottomLeftVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.BottomLeftVector;
                    break;
                case TextPositions.BottomCenter:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.BottomCenterVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.BottomCenterVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.BottomCenterVector;
                    break;
                case TextPositions.BottomRight:
                    _textBoxRectTransform.anchorMax = TutorialConstants.TextBoxPositions.BottomRightVector;
                    _textBoxRectTransform.anchorMin = TutorialConstants.TextBoxPositions.BottomRightVector;
                    _textBoxRectTransform.pivot = TutorialConstants.TextBoxPositions.BottomRightVector;
                    break;
            }
        }

        private void OnDestroy()
        {
            _cts?.Cancel();
            _cts?.Dispose();

            _skipButton.OnSkip -= OnSkip;
        }
    }
}
