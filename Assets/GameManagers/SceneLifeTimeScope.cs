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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterInstance(regionController);
            builder.RegisterComponentInHierarchy<GameUI>();
        }
    }
}
