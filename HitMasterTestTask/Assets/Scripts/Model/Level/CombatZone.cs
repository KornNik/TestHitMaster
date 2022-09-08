using System;
using UnityEngine;
using HitMaster.Model.Unit;

namespace HitMaster.Model.Level
{
    class CombatZone : MonoBehaviour
    {
        #region MyRegion

        [SerializeField] private DefaultEnemyCharacter[] _enemiesCharacters;

        public Action EnemiesKilled;
        public Action<int> EnterZone;
        public int ZoneIndex;

        private int _enemiesLeft = 0;

        #endregion


        #region Properties

        public DefaultEnemyCharacter[] EnemiesCharacters => _enemiesCharacters;
        public int EnemiesLeft
        {
            get { return _enemiesLeft; }
            set
            {
                _enemiesLeft = value;
                if (_enemiesLeft == 0)
                {
                    EnemiesKilled?.Invoke();
                }
            }
        }

        #endregion


        #region ClassLifeCycle

        private void Awake()
        {
            _enemiesLeft = _enemiesCharacters.Length;
            Invoke(nameof(DeathSubscribe), 1f);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _enemiesCharacters.Length; i++)
            {
                _enemiesCharacters[i].EventManager.Death -= OnEnemyDeath;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            var player = other.gameObject.GetComponent<DefaultPlayerCharacter>();
            if (player != null)
            {
                EnterZone?.Invoke(ZoneIndex);
            }
        }

        #endregion


        #region Methods

        private void DeathSubscribe()
        {
            for (int i = 0; i < _enemiesCharacters.Length; i++)
            {
                _enemiesCharacters[i].EventManager.Death += OnEnemyDeath;
            }
        }

        private void OnEnemyDeath()
        {
            EnemiesLeft -= 1;
        }

        #endregion
    }
}