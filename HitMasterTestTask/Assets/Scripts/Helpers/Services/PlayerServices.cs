using System;
using HitMaster.Model.Unit;

namespace HitMaster.Helpers.Services
{
    sealed class PlayerService
    {
        #region Fields

        public static Action PlayerLoaded;

        private DefaultPlayerCharacter _playerCharacter;

        #endregion


        #region Properties

        public DefaultPlayerCharacter PlayerCharacter => _playerCharacter;

        #endregion


        #region ClassLifeCycle

        public PlayerService()
        {

        }
        ~PlayerService()
        {

        }

        #endregion


        #region Mehtods

        public void SetPlayer(DefaultPlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
            PlayerLoaded?.Invoke();
        }

        #endregion
    }
}
