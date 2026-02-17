using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    /// <summary>
    /// コーチマークの形や半径を設定するモデル
    /// </summary>
    [System.Serializable]
    public class CoachMarkModel
    {
        [SerializeField, Tooltip("コーチマークの形を指定するもの")]
        private ShapeKinds _shape;
        /// <summary>
        /// コーチマークの形を指定するもの
        /// </summary>
        public ShapeKinds Shape => _shape;

        [SerializeField, Tooltip("コーチマークの半径")]
        private float _radius;
        /// <summary>
        /// コーチマークの半径
        /// </summary>
        public float Radius => _radius;

        [SerializeField, Tooltip("コーチマークの対象になるオブジェクトの名前")]
        private string _targetObjectName;
        /// <summary>
        /// コーチマークの対象になるオブジェクトの名前
        /// </summary>
        public string TargetObjectName => _targetObjectName;
    }
}