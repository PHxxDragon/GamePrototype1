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
        [SerializeField] private SquareController squarePrefab;
        [SerializeField] private Transform topLeft;
        [SerializeField] private Transform bottomRight;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(squarePrefab);
            builder.RegisterEntryPoint<SquareSpawnerController>();
            builder.RegisterInstance(topLeft).Keyed(InjectKeys.TopLeft);
            builder.RegisterInstance(bottomRight).Keyed(InjectKeys.BottomRight);
        }
    }
}
