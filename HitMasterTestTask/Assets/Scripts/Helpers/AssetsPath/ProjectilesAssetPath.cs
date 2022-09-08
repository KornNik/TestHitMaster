using System.Collections.Generic;
using HitMaster.Model.Projectile;

namespace HitMaster.Helpers.AssetsPath
{
    sealed class ProjectilesAssetPath
    {
        #region Fields

        public static readonly Dictionary<ProjectileType, string> 
            ProjectilesPath = new Dictionary<ProjectileType, string>
        {
            {
                ProjectileType.Bullet, "Prefabs/Projectiles/Prefabs_Projectiles_Bullet"
            }
        };

        #endregion
    }
}