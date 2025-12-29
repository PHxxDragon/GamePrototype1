using GameObjects.Region;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameManagers
{
    public class SceneLifeTimeScope: LifetimeScope
    {
        [SerializeField] private RegionView regionView;
        [SerializeField] private GameUI gameUI;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterInstance(regionView);
            builder.RegisterInstance(gameUI);
        }
    }
}
