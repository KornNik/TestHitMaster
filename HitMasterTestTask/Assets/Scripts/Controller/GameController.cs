using UnityEngine;

namespace HitMaster.Controller
{
    class GameController : MonoBehaviour
    {
        #region Fields



        #endregion


        #region UnityMethods

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.SetQualityLevel(0);
            Screen.orientation = ScreenOrientation.Landscape;
        }

        #endregion


        #region Methods



        #endregion
    }
}