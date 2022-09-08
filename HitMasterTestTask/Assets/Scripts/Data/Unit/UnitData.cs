using UnityEngine;

namespace HitMaster.Data.Unit
{
    [CreateAssetMenu(fileName = "UnitData", menuName ="Data/Unit/UnitData")]
    class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] float _health;
        [SerializeField] MovementData _movementData;

        #endregion


        #region Properties

        public float Health => _health;
        public MovementData MovementData => _movementData;

        #endregion
    }
}