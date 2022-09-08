using HitMaster.Model.Unit;

namespace HitMaster.Model
{
    abstract class BaseInput
    {

        #region Fields

        protected DefaultPlayerCharacter _player;

        #endregion


        #region ClassLifeCycle

        public BaseInput(DefaultPlayerCharacter player)
        {
            _player = player;
        }

        #endregion


        #region Mehtods

        public abstract void InputsEntry();

        #endregion
    }
}