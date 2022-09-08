using System;
using HitMaster.Data.Unit;
using HitMaster.Helpers.Managers;

namespace HitMaster.Model.Unit
{
    class Health
    {
        #region Fields

        public Action<float> HealthParametersChanged;

        private float _currentHealth;

        private UnitData _unitData;
        private UnitEventManager _eventManager;

        #endregion


        #region Properties

        public float CurrentHealth { get { return _currentHealth; } private set { _currentHealth = value;
                HealthParametersChanged?.Invoke(GetHealthRate()); } }

        #endregion


        #region ClassLifeCycle

        public Health(UnitData unitData, UnitEventManager eventManager)
        {
            _unitData = unitData;
            _currentHealth = _unitData.Health;
            _eventManager = eventManager;

            _eventManager.Recover += SetHealthToMax;
        }

        ~Health()
        {
            _eventManager.Recover -= SetHealthToMax;
        }

        #endregion


        #region Methods

        public virtual void TakeDamage(float damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                }
            }
        }
        public float GetHealthRate()
        {
            return CurrentHealth == 0 ? 0 : (CurrentHealth / _unitData.Health);
        }

        public void SetHealthToMax()
        {
            CurrentHealth = _unitData.Health;
        }

        #endregion
    }
}
