using UnityEngine;
using HitMaster.Model;
using HitMaster.Model.Unit;

namespace HitMaster.Controller
{
    class PlayerController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private DefaultPlayerCharacter _player;
        private BaseInput _input;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _player = GetComponent<DefaultPlayerCharacter>();
#if PLATFORM_ANDROID
            _input = new TouchScreenInput(_player);
#endif
        }
        private void FixedUpdate()
        {
            _input.InputsEntry();
        }

        #endregion
    }
}