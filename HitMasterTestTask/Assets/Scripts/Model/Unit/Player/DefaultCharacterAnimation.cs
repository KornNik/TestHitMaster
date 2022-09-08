namespace HitMaster.Model.Unit
{ 
    class DefaultCharacterAnimation : UnitAnimation<DefaultPlayerCharacter>
    {


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitBehaviour = GetComponent<DefaultPlayerCharacter>();
        }

        #endregion
    }
}