using UnityEngine;
using CommonUI.Tutorial;

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
        public ShapeKinds Shape => _shape;


        [SerializeField, Tooltip("コーチマークの半径")]
        private float _radius;
        public float Radius => _radius;


        [SerializeField, Tooltip("コーチマークの対象になるオブジェクトの名前")]
        private string _targetObjectName;
        public string TargetObjectName => _targetObjectName;
    }
}