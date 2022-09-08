using System;

namespace HitMaster.Helpers.Managers
{
    sealed class UnitEventManager
    {
        #region Fields

        public Action Death;
        public Action Recover;
        public Action<bool> Moving;

        public Action<float> HealthChanged;

        #endregion

    }
}