using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UserInterface.Screens;

namespace UserInterface
{
    [DisallowMultipleComponent]
    public sealed class UICore : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private RectTransform _screenContent = null;
        #endregion

        #region Fields
        private Dictionary<UIScreen, ScreenObserver> _screens = null;
        #endregion

        #region MonoBehaiour API
        private void Awake()
        {
            _screens = GetScreens();
        }
        #endregion

        private void Start()
        {
            OpenScreen(UIScreen.SplashScreen);
        }

        #region Public methods
        public void OpenScreen(UIScreen screen)
        {
            foreach (KeyValuePair<UIScreen, ScreenObserver> userInterfaceScreen in _screens)
            {
                bool value = screen.Equals(userInterfaceScreen.Key);
                userInterfaceScreen.Value.gameObject.SetActive(value);
            }
        }
        #endregion

        #region Methods
        private Dictionary<UIScreen, ScreenObserver> GetScreens()
        {
            List<ScreenObserver> screens = _screenContent.GetComponentsInChildren<ScreenObserver>(true).ToList();

            if (screens.Count != Enum.GetNames(typeof(UIScreen)).Length)
            {
                StringBuilder message = new StringBuilder("The number of screens implemented is ");

                message.Append(screens.Count > Enum.GetNames(typeof(UIScreen)).Length ? "more" : "less");
                message.Append($" than in {_screenContent}.");

                Debug.LogError(message.ToString());
            }

            Dictionary<UIScreen, ScreenObserver> result = new Dictionary<UIScreen, ScreenObserver>();

            foreach (ScreenObserver screen in screens)
            {
                result.Add(screen.Screen, screen);
            }

            return result;
        }
        #endregion
    }
}