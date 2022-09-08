using UnityEngine;
using HitMaster.Data.Unit;
using UnityEngine.AI;

namespace HitMaster.Model.Unit
{
    class DefaultPlayerMovement : UnitMovement
    {
        #region Fields

        protected NavMeshAgent _meshAgent;

        #endregion


        #region ClassLifeCycle

        public DefaultPlayerMovement(UnitBehaviour unit, MovementData movementData,NavMeshAgent meshAgent)
            : base(unit, movementData)
        {
            _unit = unit;
            _movementData = movementData;
            _meshAgent = meshAgent;
        }

        #endregion


        #region IMove

        public override void Move(Vector3 movingPoint)
        {
            base.Move(movingPoint);
            _meshAgent.SetDestination(movingPoint);
        }

        #endregion
    }
}
