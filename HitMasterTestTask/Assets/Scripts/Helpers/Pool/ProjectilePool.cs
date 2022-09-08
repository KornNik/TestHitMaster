using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using HitMaster.Model.Projectile;
using HitMaster.Helpers.Customs;
using HitMaster.Helpers.AssetsPath;

namespace HitMaster.Helpers.Pool
{
    sealed class ProjectilePool : PoolObjects<ProjectileType>
    {
        #region ClassLifeCycle

        public ProjectilePool(int capacityPool, Transform poolTransform) : base(capacityPool, poolTransform)
        {
            _objectPool = new Dictionary<ProjectileType, HashSet<IPoolable>>();
        }

        #endregion


        #region Methods
        public override IPoolable GetObject(ProjectileType type)
        {
            IPoolable result;
            switch (type)
            {
                case ProjectileType.Bullet:
                    result = GetBullet(GetListObject(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private IPoolable GetBullet(HashSet<IPoolable> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            if (ammunition == null)
            {
                var bullet = CustomResources.Load<Bullet>(ProjectilesAssetPath.ProjectilesPath[ProjectileType.Bullet]);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(bullet);
                    ReturnToPool(instantiate.transform);
                    instantiate.PoolTransform = _poolTransform;
                    ammunitions.Add(instantiate);
                }

                GetBullet(ammunitions);
            }
            ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            return ammunition;
        }

        #endregion
    }
}
