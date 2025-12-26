using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawner
{
    public class SquareSpawnerLifeTimeScope : LifetimeScope
    {
        [SerializeField] private SquareSpawnerView squareSpawnerView;
        [SerializeField] private SquareController squarePrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(squareSpawnerView);
            builder.RegisterInstance(squarePrefab);
            builder.RegisterEntryPoint<SquareSpawnerController>();
        }
    }
}
