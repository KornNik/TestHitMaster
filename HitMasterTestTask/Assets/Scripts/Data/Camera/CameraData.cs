using UnityEngine;

namespace HitMaster.Data.Camera
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Camera/CameraData")]
    class CameraData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _smoothFactor;

        [SerializeField] private Vector3 _offset;

        #endregion


        #region Properties

        public float SmoothFactor => _smoothFactor;
        public Vector3 Offset => _offset;

        #endregion
    }
}