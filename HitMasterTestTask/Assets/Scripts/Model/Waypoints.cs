using UnityEngine;

namespace HitMaster.Model.Level
{
    class Waypoints : MonoBehaviour
    {
        #region Fields

        [Range(0, 2f)]
        [SerializeField] private float _waypointSize;

        [SerializeField] private CombatZone[] _combatZones;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            for (int i = 0; i < _combatZones.Length; i++)
            {
                _combatZones[i].ZoneIndex = i;
            }
        }

        private void OnDrawGizmos()
        {
            foreach (var item in _combatZones)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(item.transform.position, _waypointSize);
            }

            Gizmos.color = Color.blue;
            for (int i = 0; i < _combatZones.Length - 1; i++)
            {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);

            }
        }

        #endregion


        #region Methods

        public Transform GetNextWaypoint(Transform currentWaypoint)
        {
            if (currentWaypoint == null)
            {
                return _combatZones[0].transform;
            }
            else
            {
                for (int i = 0; i < _combatZones.Length; i++)
                {
                    if (currentWaypoint == _combatZones[i].transform && i < _combatZones.Length - 1)
                    {
                        return _combatZones[i + 1].transform;
                    }
                }
                return _combatZones[0].transform;
            }
        }

        #endregion
    }
}
