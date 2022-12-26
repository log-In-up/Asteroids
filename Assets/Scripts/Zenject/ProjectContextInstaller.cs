using Zenject;
using UnityEngine;
using Application;

namespace DependencyInjection
{
    [DisallowMultipleComponent]
    public sealed class ProjectContextInstaller : MonoInstaller
    {
        #region Editor fields
        [SerializeField] private SceneLoader _sceneLoader = null;
        #endregion

        #region MonoInstaller API
        public override void InstallBindings()
        {
            BindSceneLoader();
        }
        #endregion

        #region Bindings
        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>()
                .FromInstance(_sceneLoader)
                .AsSingle()
                .NonLazy();
        }
        #endregion
    }
}