using UnityEngine;
using HitMaster.View.HealthUI;

namespace HitMaster.Model.Unit
{
    class DefaultEnemyCharacter : UnitBehaviour
    {
        #region Fields

        protected HealthBar _healthBar;
        protected Vector3 _startPosition;

        #endregion


        #region UnityMehtods

        protected override void Awake()
        {
            base.Awake();

            _healthBar = GetComponentInChildren<HealthBar>();
            _startPosition = transform.position;

            _healthBar.SetUnit(this);
            _eventManager.Recover += MoveToStartPosition;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _eventManager.Recover -= MoveToStartPosition;
        }

        #endregion



        #region Methods

        private void MoveToStartPosition()
        {
            transform.position = _startPosition;
        }

        #endregion
    }
}