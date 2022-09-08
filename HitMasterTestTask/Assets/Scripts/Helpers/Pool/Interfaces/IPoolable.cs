using UnityEngine;

namespace HitMaster.Helpers.Pool
{
    interface IPoolable
    {
        Transform PoolTransform { get; set; }
        GameObject PoolableObject { get; set; }
        void ReturnToPool();
        void ActiveObject();
    }
}
