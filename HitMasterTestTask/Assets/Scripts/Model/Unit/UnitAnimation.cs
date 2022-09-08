using UnityEngine;
using HitMaster.Helpers.Managers;

namespace HitMaster.Model.Unit
{
    class UnitAnimation<T> : MonoBehaviour 
        where T : UnitBehaviour
    {
        #region Fields

        [SerializeField] protected T _unitBehaviour;
        [SerializeField] protected Animator _unitAnimator;

        protected static readonly int _isMoving = Animator.StringToHash(UnitAnimationParametersManager.IS_MOVING);

        #endregion


        #region UnityMethods

        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            _unitBehaviour.EventManager.Moving -= OnMovingBool;
        }

        protected virtual void Awake()
        {
            _unitAnimator = GetComponent<Animator>();
        }

        #endregion


        #region Methods

        public virtual void OnMovingBool(bool isMoving)
        {
            _unitAnimator.SetBool(_isMoving, isMoving);
        }

        #endregion
    }
}