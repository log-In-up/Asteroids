using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Application
{
    [DisallowMultipleComponent]
    public sealed class SceneLoader : MonoBehaviour
    {
        #region Editor fields
        [SerializeField, Min(0)]
        private int _gameSceneIndex = 2,
            _mainSceneIndex = 1,
            _splashScreenSceneIndex = 0;
        #endregion

        #region Fields
        private Dictionary<Scenes, int> _scenes = null;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _scenes = new Dictionary<Scenes, int>()
            {
                [Scenes.Game] = _gameSceneIndex,
                [Scenes.Main] = _mainSceneIndex,
                [Scenes.SplashScreen] = _splashScreenSceneIndex
            };
        }
        #endregion

        #region Public methods
        public AsyncOperationHandle<SceneInstance> GetAsyncLoadScene(Scenes scenes, LoadSceneMode loadSceneMode, bool activateOnLoad)
        {
            return Addressables.LoadSceneAsync(_scenes[scenes], loadSceneMode, activateOnLoad);
        }
        #endregion
    }
}
