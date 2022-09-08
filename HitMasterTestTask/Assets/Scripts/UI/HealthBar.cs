using UnityEngine;
using UnityEngine.UI;
using HitMaster.Model.Unit;

namespace HitMaster.View.HealthUI
{
    class HealthBar : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Image _healthFilledImage;

        private UnitBehaviour _unit;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            if (_unit is UnitBehaviour)
            {
                if (_unit.EventManager.Death != null) return;
                _unit.EventManager.HealthChanged += HealthDisplay;
                _unit.EventManager.Death += HealthBarOff;
                _unit.EventManager.Recover += HealthBarOn;
            }
        }

        private void OnDisable()
        {
            if (_unit is UnitBehaviour)
            {
                _unit.EventManager.HealthChanged -= HealthDisplay;
                _unit.EventManager.Death -= HealthBarOff;
                _unit.EventManager.Recover -= HealthBarOn;
            }
        }

        #endregion


        #region Methods

        public void SetUnit(UnitBehaviour unit)
        {
            _unit = unit;
            _unit.EventManager.HealthChanged = HealthDisplay;
            _unit.EventManager.Death += HealthBarOff;
            _unit.EventManager.Recover += HealthBarOn;
        }

        private void HealthDisplay(float healthRate)
        {
            _healthFilledImage.fillAmount = healthRate;
        }
        private void HealthBarOff()
        {
            _healthFilledImage.enabled = false;
        }
        private void HealthBarOn()
        {
            _healthFilledImage.enabled = true;
        }

        #endregion
    }
}