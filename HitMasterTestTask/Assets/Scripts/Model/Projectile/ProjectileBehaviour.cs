using UnityEngine;
using HitMaster.Helpers.Pool;
using HitMaster.Data.Projectile;

namespace HitMaster.Model.Projectile
{
    abstract class ProjectileBehaviour : MonoBehaviour, IPoolable, IDamager
    {
        #region Fields

        [SerializeField] protected Rigidbody _projectileRigidbody;
        [SerializeField] protected ProjectileData _projectileData;

        protected Transform _poolTransform;

        #endregion


        #region Properties

        public Transform PoolTransform { get { return _poolTransform; } set { _poolTransform = value; } }

        public GameObject PoolableObject { get { return gameObject; } set { PoolableObject.SetActive(value); } }

        public ProjectileData ProjectileData => _projectileData;

        #endregion


        #region Methods

        private void ProjectileFly(Vector3 direction)
        {
            _projectileRigidbody.AddForce(direction * _projectileData.ProjectileSpeed, ForceMode.Impulse);
        }

        public void FireProjectile(Vector3 direction)
        {
            ActiveObject();
            ProjectileFly(direction);
        }

        #endregion


        #region IDamager

        public void InflictDamage(IDamageable victim)
        {
            victim.ReceiveDamage(_projectileData.Damage);
        }

        #endregion


        #region IPoolable

        public void ReturnToPool()
        {
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            _projectileRigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }

        public void ActiveObject()
        {
            gameObject.SetActive(true);
            Invoke(nameof(ReturnToPool), _projectileData.TimeToDistract);
            transform.SetParent(null);
        }

        #endregion
    }
}