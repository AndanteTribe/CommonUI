using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [Tooltip("コーチマークの形を設定する列挙型")]
    public enum ShapeKinds : byte
    {
        [InspectorName("長方形"), Tooltip("長方形")]
        Rectangle,

        [InspectorName("円形"), Tooltip("円形")]
        Circle
    }
}