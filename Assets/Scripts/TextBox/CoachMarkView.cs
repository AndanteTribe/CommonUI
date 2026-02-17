using CommonUI.Tutorial.Models;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CommonUI.Tutorial
{
    [RequireComponent(typeof(UnityEngine.RectTransform)), Tooltip("コーチマークのビュー")]
    public class CoachMarkView: MonoBehaviour
    {
        [SerializeField, Tooltip("Imageコンポーネント")]
        private Image _image;

        private RectTransform _rectTransform;
        [Tooltip("位置")]
        public RectTransform RectTransform => _rectTransform;

        [Tooltip("円コーチマークの画像")]
        public Sprite CircleCoachMarkSprite => _circleCoachMarkSprite;
        [SerializeField, Tooltip("円コーチマークの画像(内部)")]
        private Sprite _circleCoachMarkSprite;

        [Tooltip("矩形コーチマークの画像")]
        public Sprite RectangleCoachMarkSprite => _rectangleCoachMarkSprite;
        [SerializeField, Tooltip("長方形コーチマークの画像(内部)")]
        private Sprite _rectangleCoachMarkSprite;


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