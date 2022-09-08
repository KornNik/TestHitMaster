using UnityEngine;
using HitMaster.Model.Projectile;

namespace HitMaster.Model.Weapon
{
    class Pistol : WeaponBehaviour
    {

        #region Fields

        private RaycastHit _hit;

        #endregion

        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _projectileType = ProjectileType.Bullet;
        }

        #endregion


        #region Methods

        public override void Fire(Ray ray)
        {
            if (!_isReady) return;
            ProjectileBehaviour projectile;
            projectile = _projectilePool.GetObject(_projectileType) as ProjectileBehaviour;

            if (projectile != null)
            {
                if (Physics.Raycast(ray, out _hit))
                {
                    var heading = _hit.point - _poolTransform.position;
                    projectile.FireProjectile(heading.normalized);
                }
                else
                {
                    projectile.FireProjectile(ray.direction);
                }
                _isReady = false;
            }

            Invoke(nameof(IsReadyFire), _weaponData.FireDelay);
        }

        #endregion
    }
}