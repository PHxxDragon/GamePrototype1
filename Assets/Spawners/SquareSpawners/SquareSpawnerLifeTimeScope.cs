using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawners
{
    public enum InjectKeys
    {
        TopLeft,
        BottomRight
    }
    
    public class SquareSpawnerLifeTimeScope : LifetimeScope
    {
        [SerializeField] private SquareView squarePrefab;
        [SerializeField] private Transform regionTopLeft;
        [SerializeField] private Transform regionBottomRight;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(squarePrefab);
            builder.RegisterEntryPoint<SquareSpawnerController>();
            builder.RegisterInstance(regionTopLeft).Keyed(InjectKeys.TopLeft);
            builder.RegisterInstance(regionBottomRight).Keyed(InjectKeys.BottomRight);
        }
    }
}
