using System;
using System.Threading;
using UnityEngine;
using TMPro;
using CommonUI.Tutorial.Models;
using CommonUI.Tutorial.Views;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// テキストボックスのPresenter
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class TextBoxPresenter : MonoBehaviour
    {
        [SerializeField, Tooltip("反映させるテキストボックス内のTMP")]
        private TextMeshProUGUI _textMeshPro;

        [SerializeField, Tooltip("テキストボックスのRectTransform")]
        private RectTransform _textBoxRectTransform;

        [SerializeField, Tooltip("テキストボックスのマスターデータ")]
        private TextBoxMasterData _textData;

        [SerializeField, Tooltip("マスクのRectTransform")]
        private CoachMarkView _coachMaskView;

        [SerializeField, Tooltip("矩形のアニメーションフレーム")]
        private RectangleFrame _rectangleFrame;

        [SerializeField, Tooltip("円のアニメーションフレーム")]
        private CircleFrame _circleFrame;

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

        /// <summary>
        /// UIの位置を取得しておくフィールド
        /// </summary>
        private readonly Vector3[] _corners = new Vector3[4];

        private void Start()
        {
            _modelIndex = 0;

            _cts = new CancellationTokenSource();

            // スキップボタンの登録
            _skipButton.OnSkip += OnSkip;

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
                        SetCoachMark(_textData.Models[_modelIndex].Models[_pageIndex].CoachMark);
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
                SetCoachMark(_textData.Models[_modelIndex].Models[_pageIndex].CoachMark);
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

            SetBasePosition(modelData.Position);
            SetCoachMark(modelData.Models[0].CoachMark);
            AdjustPosition(modelData);

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
            _textBoxRectTransform.gameObject.SetActive(false);
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
        private void SetBasePosition(TextPositions textPosition)
        {
            // CoachMarkがズレてしまうため、anchoredPositionを初期化
            _textBoxRectTransform.anchoredPosition = Vector3.zero;

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

        /// <summary>
        /// コーチマークの位置・サイズを設定し、アニメーションフレームを調整する
        /// </summary>
        /// <param name="model">元となるモデル</param>
        private void SetCoachMark(CoachMarkModel model)
        {
            // 指定された名前のオブジェクトを探す
            var targetObject = GameObject.Find(model.TargetObjectName);

            // オブジェクトが見つからなかった場合はエラーログを出力して終了
            if (targetObject == null)
            {
                throw new NullReferenceException("対象のオブジェクトが見つかりませんでした. 指定したオブジェクト名: " + model.TargetObjectName);
            }

            // 対象のゲームオブジェクトにRectTransformがある場合
            if (targetObject.transform is RectTransform targetRect)
            {
                // 対象のゲームオブジェクトの4端のワールド座標を取得し、中心を計算。その結果を座標に当てはめる。
                targetRect.GetWorldCorners(_corners);
                var targetPosition = (_corners[0] + _corners[2]) / 2;

                _coachMaskView.MaskRectTransform.position = targetPosition;

                // コーチマークの形をモデルに合わせて変更する
                _coachMaskView.SetSprite(model.Shape);

                // モデルの形によってマスクの形を変更する
                switch (model.Shape)
                {
                    // 矩形の場合はその形のサイズに合わせる。対象のサイズにモデルの半径を加えたサイズを計算。
                    case ShapeKinds.Rectangle:
                        var targetWidth = targetRect.sizeDelta.x + model.Radius;
                        var targetHeight = targetRect.sizeDelta.y + model.Radius;
                        _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
                        _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);

                        // アニメーションフレームを設定する
                        SetAnimationFrame(model.Shape);
                        return;

                    // 円形の場合はモデルの半径の大きさに合わせる
                    case ShapeKinds.Circle:
                        _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, model.Radius);
                        _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, model.Radius);

                        // アニメーションフレームを設定する
                        SetAnimationFrame(model.Shape);
                        return;
                }
            }

            // RectTransformがない場合
            // オブジェクトの場所からUIの位置を計算する。計算した結果にUIを位置させる。
            var screenPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);
            _coachMaskView.MaskRectTransform.position = screenPosition;

            // RectTransformがない場合、モデルに関係なく円形で対応する
            _coachMaskView.SetSprite(ShapeKinds.Circle);
            _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, model.Radius);
            _coachMaskView.MaskRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, model.Radius);

            // アニメーションフレームを設定する
            SetAnimationFrame(ShapeKinds.Circle);
        }

        /// <summary>
        /// コーチマークにアニメーションフレームを合わせる
        /// </summary>
        /// <param name="shape">フレームの形</param>
        private void SetAnimationFrame(ShapeKinds shape)
        {
            // アニメーションフレームが設定されていない場合はエラーを出す
            if (_rectangleFrame == null)
            {
                throw new NullReferenceException("矩形アニメーションフレームが設定されていません。");
            }
            if(_circleFrame == null)
            {
                throw new NullReferenceException("円形アニメーションフレームが設定されていません。");
            }

            switch (shape)
            {
                // 矩形の場合
                case ShapeKinds.Rectangle:
                    _rectangleFrame.gameObject.SetActive(true);
                    _circleFrame.gameObject.SetActive(false);
                    _rectangleFrame.SetPosition(_coachMaskView.MaskRectTransform);
                    _rectangleFrame.SetSize(_coachMaskView.MaskRectTransform);
                    break;

                // 円形の場合
                case ShapeKinds.Circle:
                    _rectangleFrame.gameObject.SetActive(false);
                    _circleFrame.gameObject.SetActive(true);
                    _circleFrame.SetPosition(_coachMaskView.MaskRectTransform);
                    _circleFrame.SetSize(_coachMaskView.MaskRectTransform);
                    break;
            }
        }

        /// <summary>
        /// コーチマークから相対座標を設定する
        /// </summary>
        /// <param name="model">テキストボックスモデル</param>
        private void AdjustPosition(TextBoxModel model)
        {
            // 両方ともZeroならば相対座標の設定は行わない。
            if (model.RadiusHorizontalOffset == ValueKinds.Zero &&
                model.RadiusVerticalOffset == ValueKinds.Zero)
            {
                return;
            }

            // コーチマークの座標を取得し、中心座標を計算する。
            _coachMaskView.MaskRectTransform.GetWorldCorners(_corners);
            var targetPosition = (_corners[0] + _corners[2]) / 2;

            // テキストボックスの座標をコーチマークの中心に合わせる。
            _textBoxRectTransform.position = targetPosition;

            // コーチマークとテキストボックスの中心を合わせるため、テキストボックスの4端のワールド座標を取得し、中心を計算する。
            _textBoxRectTransform.GetWorldCorners(_corners);
            var textBoxPosition = (_corners[0] + _corners[2]) / 2;

            // コーチマークの中心とテキストボックスの中心の差分を計算する。
            var offset = targetPosition - textBoxPosition;

            // 差分と指定したズレの分ズラす。
            _textBoxRectTransform.position += offset + new Vector3((float)model.RadiusHorizontalOffset, (float)model.RadiusVerticalOffset, 0);
        }

        private void OnDestroy()
        {
            _cts?.Cancel();
            _cts?.Dispose();

            _skipButton.OnSkip -= OnSkip;
        }
    }
}