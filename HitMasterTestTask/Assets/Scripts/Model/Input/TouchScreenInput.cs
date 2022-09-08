using UnityEngine;
using HitMaster.Model.Unit;

namespace HitMaster.Model
{
    class TouchScreenInput : BaseInput
    {
        #region Fields

        private Camera _camera;
        private Touch[] _touches;

        #endregion


        #region ClassLifeCycle

        public TouchScreenInput(DefaultPlayerCharacter player) : base(player)
        {
            _player = player;
            _camera = Camera.main;
        }

        #endregion


        #region Methods

        public override void InputsEntry()
        {
            if (Input.touchCount > 0)
            {
                _touches = Input.touches;
                var ray = _camera.ScreenPointToRay(_touches[0].position);

                _player.Weapon.Fire(ray);
            }
        }

        #endregion
    }
}