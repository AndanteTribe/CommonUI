using CommonUI.Tutorial.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CommonUI.Tutorial
{
    /// <summary>
    /// コーチマークのビュー
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class CoachMarkView: MonoBehaviour
    {
        [SerializeField, Tooltip("Imageコンポーネント")]
        private Image _image;

        private RectTransform _rectTransform;
        /// <summary>
        /// 位置
        /// </summary>
        public RectTransform RectTransform => _rectTransform;

        [SerializeField, Tooltip("円コーチマークの画像")]
        private Sprite _circleCoachMarkSprite;
        public Sprite CircleCoachMarkSprite => _circleCoachMarkSprite;

        [SerializeField, Tooltip("長方形コーチマークの画像")]
        private Sprite _rectangleCoachMarkSprite;
        public Sprite RectangleCoachMarkSprite => _rectangleCoachMarkSprite;

        private void Start()
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
                    _image.sprite = RectangleCoachMarkSprite;
                    break;
                case ShapeKinds.Circle:
                    _image.sprite = CircleCoachMarkSprite;
                    break;
            }
        }
    }
}