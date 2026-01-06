using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Views
{
    public class SkipView : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
    {
        /// <summary>
        /// スキップまでに長押しする時間
        /// </summary>
        [SerializeField, Tooltip("スキップが完了するのにかかる時間")]
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

        private float _timestamp;
        private bool _isHolding;
        private Coroutine _coroutine;

        private void Start() => _frame.fillAmount = 0;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
            _coroutine ??= StartCoroutine(FrameController());
        }

        public void OnPointerUp(PointerEventData eventData) => _isHolding = false;

        public void OnPointerExit(PointerEventData eventData) => _isHolding = false;

        private IEnumerator FrameController()
        {
            while (_isHolding || _frame.fillAmount >= 0)
            {
                var rate = Time.deltaTime / _duration;
                if (_isHolding)
                {
                    _frame.fillAmount += rate;

                    // ゲージがいっぱいになったら完了処理
                    if (_frame.fillAmount >= 1.0f)
                    {
                        Complete();
                        yield break;
                    }
                }
                else
                {
                    _frame.fillAmount -= rate;
                }

                yield return null;
            }
        }

        private void Complete()
        {
            OnSkip?.Invoke();
            _frame.fillAmount = 0;
            _isHolding = false;
            _coroutine = null;
        }
    }
}