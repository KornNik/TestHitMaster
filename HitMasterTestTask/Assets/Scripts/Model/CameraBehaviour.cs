using UnityEngine;
using HitMaster.Data.Camera;

namespace HitMaster.Model.CameraSpace
{
    class CameraBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Camera _camera;
        [SerializeField] private CameraData _cameraData;

        [SerializeField] private Transform _target;

        #endregion


        #region UnityMethods


        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _camera.transform.SetParent(_target);
        }

        private void FixedUpdate()
        {
            CameraMovingToTarget(_target.transform);
        }

        #endregion


        #region Methods

        private void CameraMovingToTarget(Transform target)
        {
            var desiredPosition = target.position + _cameraData.Offset;
            var lerpPostion = Vector3.Lerp(transform.position, desiredPosition,
                _cameraData.SmoothFactor * Time.fixedDeltaTime);
            transform.position = lerpPostion;
            transform.LookAt(target.position);
        }

        #endregion
    }
}
