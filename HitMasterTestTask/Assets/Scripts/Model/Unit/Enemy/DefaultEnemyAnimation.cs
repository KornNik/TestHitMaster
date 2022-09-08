namespace HitMaster.Model.Unit
{
    class DefaultEnemyAnimation : UnitAnimation<DefaultEnemyCharacter>
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitBehaviour = GetComponent<DefaultEnemyCharacter>();
        }

        #endregion
    }
}