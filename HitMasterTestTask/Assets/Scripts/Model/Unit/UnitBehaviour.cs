using UnityEngine;
using UnityEngine.AI;
using HitMaster.Helpers.Managers;
using HitMaster.Data.Unit;

namespace HitMaster.Model.Unit
{
    abstract class UnitBehaviour : MonoBehaviour, IDamageable
    {
        #region Fields

        [SerializeField] protected UnitData _unitData;
        [SerializeField] protected NavMeshAgent _agent;

        protected Health _health;
        protected UnitDeath _death;
        protected MotionManager _motionManager;
        protected UnitEventManager _eventManager;
        protected Rigidbody[] _ragdollRigidbodies;

        #endregion


        #region Properties

        public UnitData UnitData => _unitData;
        public NavMeshAgent NavMeshAgent => _agent;

        public Health Health => _health;
        public UnitDeath UnitDeath => _death;
        public UnitEventManager EventManager => _eventManager;
        public MotionManager MotionManager => _motionManager;
        public Rigidbody[] RagdollRigidbodies => _ragdollRigidbodies;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

            _eventManager = new UnitEventManager();
            _health = new Health(_unitData, _eventManager);
            _death = new UnitDeath(this, GetComponent<Animator>());
        }
        protected virtual void OnEnable()
        {
            _health.HealthParametersChanged += OnHealthChaged;
        }

        protected virtual void OnDisable()
        {
            _health.HealthParametersChanged -= OnHealthChaged;
        }

        #endregion


        #region Methods

        private void OnHealthChaged(float health)
        {
            _eventManager.HealthChanged?.Invoke(health);
        }

        #endregion


        #region IDamageable

        public void ReceiveDamage(float damage)
        {
            if (_death.IsDead) return;
            _health.TakeDamage(damage);
            if (_health.CurrentHealth == 0)
            {
                _eventManager.Death?.Invoke();
            }
        }

        #endregion
    }
}