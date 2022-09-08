using UnityEngine;

namespace HitMaster.Data.Weapon
{
    [CreateAssetMenu(fileName ="WeaponData", menuName ="Data/Weapon/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _fireDelay;

        #endregion


        #region Properties

        public float FireDelay => _fireDelay;

        #endregion
    }
}