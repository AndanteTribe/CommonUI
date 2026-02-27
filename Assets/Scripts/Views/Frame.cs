using UnityEngine;

namespace CommonUI.Tutorial.Views
{
    public abstract class Frame : MonoBehaviour
    {
        /// <summary>
        /// コーチマークの座標に合わせる。
        /// </summary>
        /// <param name="coachMarkPos">対象のコーチマークの位置</param>
        public abstract void SetPosition(RectTransform coachMarkPos);

        /// <summary>
        /// コーチマークのサイズに合わせる。
        /// </summary>
        /// <param name="coachMarkPos">対象のコーチマークの位置</param>
        public abstract void SetSize(RectTransform coachMarkPos);
    }
}