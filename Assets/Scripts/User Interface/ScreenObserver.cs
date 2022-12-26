using UnityEngine;

namespace UserInterface.Screens
{
    [DisallowMultipleComponent]
    public abstract class ScreenObserver : MonoBehaviour
    {
        #region Editor fields
        [Header("Observer base components")]
        [SerializeField] private UICore _uiCore = null;
        #endregion

        #region Properties
        public abstract UIScreen Screen { get; }

        public UICore UICore => _uiCore;
        #endregion

        #region Public methods
        public abstract void Activate();
        public abstract void Deactivate();
        #endregion
    }
}