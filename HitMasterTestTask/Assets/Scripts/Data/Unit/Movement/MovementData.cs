using UnityEngine;

namespace HitMaster.Data.Unit
{
    [CreateAssetMenu(fileName ="UnitMovementData",menuName ="Data/Unit/Movement")]
    class MovementData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _movementSpeed;

        #endregion


        #region Properties

        public float MovementSpeed => _movementSpeed;

        #endregion


    }
}