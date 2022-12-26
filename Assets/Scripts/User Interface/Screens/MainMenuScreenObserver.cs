using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace UserInterface.Screens
{
    public sealed class MainMenuScreenObserver : ScreenObserver
    {
        #region Properties
        public override UIScreen Screen => UIScreen.MainMenuScreen;
        #endregion

        #region Public methods
        public override void Activate()
        {

        }

        public override void Deactivate()
        {

        }
        #endregion
    }
}