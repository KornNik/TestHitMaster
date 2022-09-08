using UnityEngine;
using HitMaster.Model.Unit;

namespace HitMaster.Model.Level
{
    class LevelBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Waypoints _waypoints;
        [SerializeField] private CombatZone[] _combatZones;
        [SerializeField] private WaypointsMover _waypointMover;

        private int _clearedZone = 0;

        #endregion


        #region Properties

        public CombatZone[] CombatZones => _combatZones;
        private int ClearedZone
        {
            get { return _clearedZone; }
            set
            {
                _clearedZone = value;
                if (_clearedZone == _combatZones.Length)
                {
                    RestartLevel();
                }
            }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            for (int i = 0; i < _combatZones.Length; i++)
            {
                _combatZones[i].ZoneIndex = i;
                _combatZones[i].EnterZone += CheckZone;
                _combatZones[i].EnemiesKilled += GoToNextZone;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < _combatZones.Length; i++)
            {
                _combatZones[i].EnterZone -= CheckZone;
                _combatZones[i].EnemiesKilled -= GoToNextZone;
            }
        }

        #endregion


        #region Methods

        private void RestartLevel()
        {
            for (int i = 0; i < _combatZones.Length; i++)
            {
                for (int j = 0; j < _combatZones[i].EnemiesCharacters.Length; j++)
                {
                    _combatZones[i].EnemiesCharacters[j].EventManager.Recover?.Invoke();
                }
            }
            ClearedZone = 0;
        }
        private void CheckZone(int zoneIndex)
        {
            if (_combatZones[zoneIndex].EnemiesLeft==0)
            {
                GoToNextZone();
            }
        }
        private void GoToNextZone()
        {
            if(_waypointMover != null)
            {
                _waypointMover.GetToNextPosition();
                ClearedZone++;
            }
        }

        #endregion
    }
}