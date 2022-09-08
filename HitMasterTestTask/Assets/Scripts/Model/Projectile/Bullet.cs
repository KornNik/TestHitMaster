using UnityEngine;

namespace HitMaster.Model.Projectile
{
    class Bullet : ProjectileBehaviour
    {
        #region UnityMethods

        private void OnCollisionEnter(Collision collision)
        {
            var victim = collision.gameObject.GetComponentInParent<IDamageable>();
            if(victim != null)
            {
                InflictDamage(victim);
            }
            ReturnToPool();
        }

        #endregion
    }
}