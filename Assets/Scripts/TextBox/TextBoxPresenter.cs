using System;
using UnityEngine;
using TMPro;
using CommonUI.Tutorial.Models;

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

        /// <summary>
        /// 現在のtextModelモデルの番号
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// UIの位置を取得しておくフィールド
        /// </summary>
        private readonly Vector3[] _corners = new Vector3[4];

        private void Start()
        {
            _index = 0;
            SetBasePosition(_textData.Models[_index].Position);
            SetCoachMark(_textData.Models[_index].Models[0].CoachMark);
            AdjustPosition(_textData.Models[_index]);
        }

        private void Update()
        {
            //クリックしたら次のモデルを参照し、SetPositionを実行させる
            if (Input.GetMouseButtonDown(0))
            {
                SetBasePosition(_textData.Models[_index].Position);
                SetCoachMark(_textData.Models[_index].Models[0].CoachMark);
                AdjustPosition(_textData.Models[_index]);
                _index++;
            }
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
        /// コーチマークの位置・サイズを設定する
        /// </summary>
        /// <param name="model">元となるモデル</param>
        private void SetCoachMark(CoachMarkModel model)
        {
            // 指定された名前のオブジェクトを探す
            var targetObject = GameObject.Find(model.TargetObjectName);

            // オブジェクトが見つからなかった場合はエラーログを出力して終了
            if (targetObject != null)
            {
                throw new NullReferenceException("対象のオブジェクトが見つかりませんでした. 指定したオブジェクト名: " + model.TargetObjectName);
            }

            // 対象のゲームオブジェクトにRectTransformがある場合
            if (targetObject.transform is RectTransform targetRect)
            {
                // 対象のゲームオブジェクトの4端のワールド座標を取得し、中心を計算。その結果を座標に当てはめる。
                targetRect.GetWorldCorners(_corners);
                var targetPosition = (_corners[0] + _corners[2]) / 2;

                _coachMaskView.RectTransform.position = targetPosition;

                // コーチマークの形をモデルに合わせて変更する
                _coachMaskView.SetSprite(model.Shape);

                // モデルの形によってマスクの形を変更する
                switch (model.Shape)
                {
                    // 矩形の場合はその形のサイズに合わせる。対象のサイズにモデルの半径を加えたサイズを計算。
                    case ShapeKinds.Rectangle:
                        var targetWidth = targetRect.sizeDelta.x + model.Radius;
                        var targetHeight = targetRect.sizeDelta.y + model.Radius;
                        _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
                        _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
                        return;

                    // 円形の場合はモデルの半径の大きさに合わせる
                    case ShapeKinds.Circle:
                        _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, model.Radius);
                        _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, model.Radius);
                        return;
                }
            }

            // RectTransformがない場合
            // オブジェクトの場所からUIの位置を計算する。計算した結果にUIを位置させる。
            var screenPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);
            _coachMaskView.RectTransform.position = screenPosition;

            // RectTransformがない場合、モデルに関係なく円形で対応する
            _coachMaskView.SetSprite(ShapeKinds.Circle);
            _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, model.Radius);
            _coachMaskView.RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, model.Radius);
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
            _coachMaskView.RectTransform.GetWorldCorners(_corners);
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
    }
}
