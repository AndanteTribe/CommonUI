using System;
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

        /// <summary>
        /// マスクのRectTransform
        /// </summary>
        [SerializeField]
        private RectTransform _coachMaskRect;

        /// <summary>
        /// 画像の配列
        /// </summary>
        [SerializeField]
        private Sprite[] _coachMarkSprites;

        [SerializeField]
        private RectTransform[] _coachMarkAnim;

        private void Start()
        {
            _index = 0;
            SetPosition(_textData.Models[_index].Position);
            SetCoachMarkShape(_textData.Models[_index].Models[0].CoachMark.Shape);
            SetCoachMark(_textData.Models[_index].Models[0].CoachMark);
        }

        private void Update()
        {
            //クリックしたら次のモデルを参照し、SetPositionを実行させる
            if (Input.GetMouseButtonDown(0))
            {
                SetPosition(_textData.Models[_index].Position);
                SetCoachMarkShape(_textData.Models[_index].Models[0].CoachMark.Shape);
                SetCoachMark(_textData.Models[_index].Models[0].CoachMark);
                _index++;
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
        /// コーチマークの形を設定する
        /// </summary>
        /// <param name="model"> 設定するモデル </param>
        private void SetCoachMarkShape(ShapeKinds model)
        {
            switch (model)
            {
                case ShapeKinds.Rectangle:
                    _coachMaskRect.GetComponent<UnityEngine.UI.Image>().sprite = _coachMarkSprites[0];
                    break;
                case ShapeKinds.Circle:
                    _coachMaskRect.GetComponent<UnityEngine.UI.Image>().sprite = _coachMarkSprites[1];
                    break;
            }
        }

        /// <summary>
        /// コーチマークの位置・形・サイズを設定する
        /// </summary>
        /// <param name="model">元となるモデル</param>
        private void SetCoachMark(CoachMarkModel model)
        {
            // 指定された名前のオブジェクトを探す
            GameObject targetObject = GameObject.Find(model.TargetObjectName);

            // オブジェクトが見つからなかった場合はエラーログを出力して終了
            if (!targetObject)
            {
                Debug.LogError("指定されたオブジェクトが見つかりませんでした: " + model.TargetObjectName);
                return;
            }

            // 対象のゲームオブジェクトにRectTransformがある場合
            if (targetObject.TryGetComponent<RectTransform>(out var targetRect))
            {
                // 対象のゲームオブジェクトの4端のワールド座標を取得し、その中心を計算。その結果を座標に当てはめる。
                var corners = new Vector3[4];
                targetRect.GetWorldCorners(corners);
                Vector3 targetPosition = (corners[0] + corners[2]) / 2;
                _coachMaskRect.position = targetPosition;

                // モデルの形によってマスクの形を変更する
                switch (model.Shape)
                {
                    // 矩形の場合はその形のサイズに合わせる。対象のサイズにモデルの半径を加えたサイズを計算。
                    case ShapeKinds.Rectangle:
                        var targetWidth = targetRect.sizeDelta.x + model.Radius;
                        var targetHeight = targetRect.sizeDelta.y + model.Radius;
                        _coachMaskRect.sizeDelta = new Vector2(targetWidth, targetHeight);
                        break;

                    // 円形の場合はモデルの半径の大きさに合わせる
                    case ShapeKinds.Circle:
                        _coachMaskRect.sizeDelta = Vector2.one * model.Radius;
                        break;
                }
            }
            // RectTransformがない場合
            else
            {
                // オブジェクトの場所からUIの位置を計算する。計算した結果にUIを位置させる。
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);
                _coachMaskRect.position = screenPosition;

                // RectTransformがない場合、モデルに関係なく円形で対応する
                _coachMaskRect.GetComponent<UnityEngine.UI.Image>().sprite = _coachMarkSprites[1];
                _coachMaskRect.sizeDelta = Vector2.one * model.Radius;
            }
        }
    }
}
