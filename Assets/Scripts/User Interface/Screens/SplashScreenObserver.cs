using Application;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Screens
{
    public sealed class SplashScreenObserver : ScreenObserver
    {
        #region Editor fields
        [Header("Splash screen components")]
        [SerializeField] private Slider _loadProgressBar = null;
        [SerializeField] private TextMeshProUGUI _loadStatus = null;
        #endregion

        #region Fields
        private Coroutine _loadingSceneStream;
        private SceneLoader _sceneLoader = null;

        private const float DELAY_BEFORE_SWITCH_SCENE = 2.0f;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.SplashScreen;
        #endregion

        #region Public methods
        public override void Activate()
        {
            _loadingSceneStream = StartCoroutine(LoadSceneStream());
        }

        public override void Deactivate()
        {
            
        }
        #endregion

        #region IEnumerators
        private IEnumerator LoadSceneStream()
        {
            AsyncOperationHandle<SceneInstance> asyncSceneLoad = _sceneLoader.GetAsyncLoadScene(Scenes.Main, LoadSceneMode.Single, false);

            _loadProgressBar.value = asyncSceneLoad.PercentComplete;
            _loadStatus.text = asyncSceneLoad.PercentComplete.ToString("0.00%");

            while (asyncSceneLoad.Status != AsyncOperationStatus.Succeeded)
            {
                yield return new WaitForEndOfFrame();

                _loadProgressBar.value = asyncSceneLoad.PercentComplete;
                _loadStatus.text = asyncSceneLoad.PercentComplete.ToString("0.00%");
            }

            yield return new WaitForSeconds(DELAY_BEFORE_SWITCH_SCENE);

            asyncSceneLoad.Result.ActivateAsync();

            UICore.OpenScreen(UIScreen.MainMenuScreen);
        }
        #endregion
    }
}