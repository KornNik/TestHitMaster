using UnityEngine;

namespace HitMaster.Data.Projectile
{
    [CreateAssetMenu(fileName ="ProjectileData", menuName ="Data/Projectile/ProjectileData")]
    class ProjectileData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _damage;
        [SerializeField] private float _timeToDistract;
        [SerializeField] private float _impulseForce;
        [SerializeField] private float _projectileSpeed;

        #endregion


        #region Properties

        public float Damage => _damage;
        public float TimeToDistract => _timeToDistract;
        public float ImpulseForce => _impulseForce;
        public float ProjectileSpeed => _projectileSpeed;

        #endregion
    }
}