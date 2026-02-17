using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [Tooltip("座標をどれくらいズラすか")]
    public enum ValueKinds : int
    {
        [Tooltip("ズラさない")]
        [InspectorName("0")]
        Zero = 0,

        [Tooltip("100pxズラす")]
        [InspectorName("+100")]
        Small = 100,

        [Tooltip("200pxズラす")]
        [InspectorName("+200")]
        Medium = 200,

        [Tooltip("300pxズラす")]
        [InspectorName("+300")]
        Large = 300,

        [Tooltip("400pxズラす")]
        [InspectorName("+400")]
        VeryLarge = 400,

        [Tooltip("-100pxズラす")]
        [InspectorName("-100")]
        NegativeSmall = -100,

        [Tooltip("-200pxズラす")]
        [InspectorName("-200")]
        NegativeMedium = -200,

        [Tooltip("-300pxズラす")]
        [InspectorName("-300")]
        NegativeLarge = -300,

        [Tooltip("-400pxズラす")]
        [InspectorName("-400")]
        NegativeVeryLarge = -400
    }
}