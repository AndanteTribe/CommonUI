using CommonUI.Tutorial.Models;
using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    public class FingerView : MonoBehaviour
    {
        [SerializeField, Tooltip("指の位置")]
        private RectTransform _rectTransform;

        public void SetDirection(FingerKinds kind)
        {
            switch (kind)
            {
                case FingerKinds.Top:
                    _rectTransform.localRotation = TutorialConstants.FingerRotations.UpperQuaternion;
                    break;
                case FingerKinds.Bottom:
                    _rectTransform.localRotation = TutorialConstants.FingerRotations.BottomQuaternion;
                    break;
                case FingerKinds.Left:
                    _rectTransform.localRotation = TutorialConstants.FingerRotations.LeftQuaternion;
                    break;
                case FingerKinds.Right:
                    _rectTransform.localRotation = TutorialConstants.FingerRotations.RightQuaternion;
                    break;
            }
        }
    }
}