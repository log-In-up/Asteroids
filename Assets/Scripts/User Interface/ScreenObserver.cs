using UnityEngine;

namespace UserInterface.Screens
{
    [DisallowMultipleComponent]
    public abstract class ScreenObserver : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private UICore _uiCore = null;
        #endregion

        #region Properties
        public virtual UIScreen Screen { get; }
        #endregion
    }
}