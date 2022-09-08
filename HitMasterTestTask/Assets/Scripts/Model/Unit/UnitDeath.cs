using UnityEngine;

namespace HitMaster.Model.Unit
{
    class UnitDeath
    {
        #region Fields

        private Animator _animator;
        private UnitBehaviour _unit;

        protected bool _isDead;

        #endregion


        #region Properties

        public bool IsDead => _isDead;

        #endregion


        #region ClassLifeCycle

        public UnitDeath(UnitBehaviour unit, Animator animator)
        {
            _unit = unit;
            _animator = animator;
            SwitchRagdoll(false);

            _unit.EventManager.Death += Dead;
            _unit.EventManager.Recover += Recover;
        }
        ~UnitDeath()
        {
            _unit.EventManager.Death -= Dead;
            _unit.EventManager.Recover -= Recover;
        }

        #endregion


        #region Methods

        private void Dead()
        {
            _isDead = true;
            SwitchRagdoll(true);
        }
        private void Recover()
        {
            _isDead = false;
            SwitchRagdoll(false);
        }

        private void SwitchRagdoll(bool isEnable)
        {
            _animator.enabled = !isEnable;
            foreach (var item in _unit.RagdollRigidbodies)
            {
                item.isKinematic = !isEnable;
            }
        }
        #endregion
    }
}