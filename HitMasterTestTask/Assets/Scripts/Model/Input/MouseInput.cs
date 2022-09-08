using UnityEngine;
using HitMaster.Model.Unit;

namespace HitMaster.Model
{
    class MouseInput : BaseInput
    {
        #region Fields

        private Camera _camera;

        #endregion


        #region ClassLifeCycle

        public MouseInput(DefaultPlayerCharacter player) : base(player)
        {
            _player = player;
            _camera = Camera.main;
        }

        #endregion


        #region Methods

        public override void InputsEntry()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButton(0))
            {
                _player.Weapon.Fire(ray);
            }
        }

        #endregion
    }
}
