using UnityEngine;
using HitMaster.Data.Unit;

namespace HitMaster.Model.Unit
{
    abstract class UnitMovement : IMove
    {
        #region Fields

        protected UnitBehaviour _unit;
        protected MovementData _movementData;

        protected Vector2 _movementPosition;

        #endregion


        #region ClassLifeCycle

        public UnitMovement(UnitBehaviour unit, MovementData movementData)
        {
            _movementData = movementData;
            _unit = unit;
        }

        #endregion


        #region IMove

        public virtual void Move(Vector3 movingPoint)
        {
            _unit.EventManager.Moving(true);
        }

        #endregion
    }
}