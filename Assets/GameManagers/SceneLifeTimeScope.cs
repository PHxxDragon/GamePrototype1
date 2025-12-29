using GameObjects.Region;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameManagers
{
    public class SceneLifeTimeScope: LifetimeScope
    {
        [SerializeField] private RegionController regionController;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private GameObject regionCenter;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterInstance(regionController);
            builder.RegisterInstance(gameUI);
        }
    }
}
