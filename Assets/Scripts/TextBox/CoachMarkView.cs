using CommonUI.Tutorial.Models;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// コーチマークのビュー
    /// </summary>
    public class CoachMarkView: MonoBehaviour
    {
        /// <summary>
        /// Imageコンポーネント
        /// </summary>
        [SerializeField]
        private Image _image;

        /// <summary>
        /// 位置
        /// </summary>
        private RectTransform _rectTransform;
        public RectTransform RectTransform => _rectTransform;

        /// <summary>
        /// コーチマークの画像配列
        /// </summary>
        [SerializeField]
        private Sprite[] _coachMarkSprite;

        public void Awake()
        {
            _rectTransform = (RectTransform)_image.transform;
        }

        /// <summary>
        /// コーチマークの形を設定する
        /// </summary>
        /// <param name="kind">指定する形</param>
        public void SetSprite(ShapeKinds kind)
        {
            switch (kind)
            {
                case ShapeKinds.Rectangle:
                    _image.sprite = _coachMarkSprite[0];
                    break;
                case ShapeKinds.Circle:
                    _image.sprite = _coachMarkSprite[1];
                    break;
            }
        }
    }
}