using UnityEngine;
using HitMaster.Model.Level;

namespace HitMaster.Model.Unit
{
    class WaypointsMover : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Waypoints _waypoints;
        [SerializeField] private DefaultPlayerCharacter _player;

        private Transform _currentWaypoint;

        #endregion


        #region Properties

        public Transform CurrentWaypoint => _currentWaypoint;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _currentWaypoint = _waypoints.GetNextWaypoint(_currentWaypoint);
            SetStartPosition();
        }

        #endregion


        #region Methods

        public void SetStartPosition()
        {
            _player.transform.position = _currentWaypoint.position;
            _player.transform.rotation = _currentWaypoint.rotation;
        }
        public void GetToNextPosition()
        {
            if (_player.NavMeshAgent.hasPath) return;
            _currentWaypoint = _waypoints.GetNextWaypoint(_currentWaypoint);
            _player.MotionManager.Movement.Move(_currentWaypoint.position);
        }

        #endregion
    }
}
