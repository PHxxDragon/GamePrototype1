using GameObjects.Region;
using GameObjects.Square;
using GameObjects.SquareChild;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameManagers
{
    public enum InjectKeys
    {
        Prefab
    }
    public class SceneLifeTimeScope: LifetimeScope
    {
        [SerializeField] private SquareView squarePrefab;
        [SerializeField] private SquareChildView squareChildPrefab;
        [SerializeField] private RegionView regionView;
        [SerializeField] private GameUI gameUI;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(squarePrefab).As<SquareView>().Keyed(InjectKeys.Prefab);
            builder.RegisterInstance(squareChildPrefab).As<SquareChildView>().Keyed(InjectKeys.Prefab);
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterInstance(regionView);
            builder.RegisterInstance(gameUI);
            builder.Register<SquareFactory>(Lifetime.Singleton);
            builder.Register<SquareChildFactory>(Lifetime.Singleton);
        }
    }
}
