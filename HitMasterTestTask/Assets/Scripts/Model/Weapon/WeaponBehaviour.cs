using UnityEngine;
using HitMaster.Data.Weapon;
using HitMaster.Helpers.Pool;
using HitMaster.Model.Projectile;

namespace HitMaster.Model.Weapon
{
    abstract class WeaponBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected Transform _poolTransform;
        [SerializeField] protected WeaponData _weaponData;

        protected PoolObjects<ProjectileType> _projectilePool;
        protected ProjectileType _projectileType = ProjectileType.Bullet;

        protected bool _isReady = true;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _projectilePool = new ProjectilePool(5, _poolTransform);
        }

        #endregion


        #region Methods

        protected void IsReadyFire()
        {
            _isReady = true;
        }

        public abstract void Fire(Ray ray);

        #endregion
    }
}