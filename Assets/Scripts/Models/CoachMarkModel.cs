using UnityEngine;

namespace CommonUI.Tutorial.Models
{
    ///<summary>
    /// コーチマークの形や半径を設定するモデル
    /// </summary>
    [System.Serializable]
    public class CoachMarkModel
    {
        /// <summary>
        /// コーチマークの形を指定するもの
        /// </summary>
        public ShapeKinds Shape => _shape;
        [SerializeField]
        private ShapeKinds _shape;

        /// <summary>
        /// コーチマークの半径
        /// </summary>
        public float Radius => _radius;
        [SerializeField]
        private float _radius;

        /// <summary>
        /// コーチマークの対象になるオブジェクトの名前
        /// </summary>
        public string TargetObjectName => _targetObjectName;
        [SerializeField]
        private string _targetObjectName;
    }
}