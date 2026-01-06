using System;
using System.Collections;
using System.Threading;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CommonUI.Tutorial.Views
{
    public class SkipView : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
    {
        /// <summary>
        /// スキップまでに長押しする時間
        /// </summary>
        [SerializeField, Tooltip("スキップまでに長押しする時間")]
        private float _duration;

        /// <summary>
        /// 長押し時にたまるゲージ
        /// </summary>
        [SerializeField]
        private Image _frame;

        /// <summary>
        /// スキップ時に発火するイベント
        /// </summary>
        public event Action OnSkip;

        private MotionHandle _handle;

        private Coroutine _coroutine;

        private void Start()
        {
            OnSkip += () => Debug.Log("Skip");
            _frame.fillAmount = 0;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            AnimateFrame(1);
            _coroutine = StartCoroutine(Skip());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_coroutine == null)
            {
                return;
            }
            StopCoroutine(_coroutine);
            _coroutine = null;
            AnimateFrame(0);
        }

        public void OnPointerExit(PointerEventData eventData) => OnPointerUp(eventData);

        private void AnimateFrame(float target)
        {
            if (_handle.IsActive())
            {
                _handle.Cancel();
            }

            var current = _frame.fillAmount;
            var distance = Mathf.Abs(target - current);
            var animDuration = _duration * distance;

            _handle = LMotion.Create(current, target, animDuration)
                .BindToFillAmount(_frame)
                .AddTo(this);
        }

        private IEnumerator Skip()
        {
            var time = _duration * (1.0f - _frame.fillAmount);
            yield return new WaitForSeconds(time);
            OnSkip?.Invoke();
            _frame.fillAmount = 0;
        }
    }
}