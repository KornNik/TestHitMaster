namespace HitMaster.Model.Unit
{
    class MotionManager
    {
        #region Fields

        private UnitBehaviour _unit;
        private UnitMovement _movement;

        #endregion


        #region Properties
        public UnitMovement Movement => _movement;

        #endregion


        #region ClassLifeCycle

        public MotionManager(UnitBehaviour unit, UnitMovement movement)
        {
            _unit = unit;
            _movement = movement;
        }

        #endregion
    }
}