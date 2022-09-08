using HitMaster.Model.Weapon;
using HitMaster.Helpers.Services;

namespace HitMaster.Model.Unit
{
    class DefaultPlayerCharacter : UnitBehaviour
    {
        #region Fields

        protected WeaponBehaviour _weapon;
        protected UnitAnimation<DefaultPlayerCharacter> _unitAnimation;

        #endregion


        #region Properties

        public WeaponBehaviour Weapon => _weapon;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();

            _weapon = GetComponentInChildren<WeaponBehaviour>();
            _unitAnimation = GetComponent<UnitAnimation<DefaultPlayerCharacter>>();

            _motionManager = new MotionManager(this, 
                new DefaultPlayerMovement(this, UnitData.MovementData, NavMeshAgent));

            SubscribeEvent();

            Services.Instance.PlayerService.SetPlayer(this);
        }

        private void FixedUpdate()
        {
            if (!_agent.hasPath)
            {
                _eventManager.Moving?.Invoke(false);
            }
        }

        #endregion


        #region Methods

        private void SubscribeEvent()
        {
            _eventManager.Moving += _unitAnimation.OnMovingBool;
        }

        #endregion
    }
}