using UnityEngine;
using CommonUI.Tutorial;

namespace CommonUI.Tutorial.Models
{
    [System.Serializable, Tooltip("コーチマークの形や半径を設定するモデル")]
    public class CoachMarkModel
    {
        [Tooltip("コーチマークの形を指定するもの")]
        public ShapeKinds Shape => _shape;
        [SerializeField, Tooltip("コーチマークの形を指定するもの（内部）")]
        private ShapeKinds _shape;

        [Tooltip("コーチマークの半径")]
        public float Radius => _radius;
        [SerializeField, Tooltip("コーチマークの半径（内部）")]
        private float _radius;

        [Tooltip("コーチマークの対象になるオブジェクトの名前")]
        public string TargetObjectName => _targetObjectName;
        [SerializeField, Tooltip("コーチマークの対象になるオブジェクトの名前（内部）")]
        private string _targetObjectName;
    }
}