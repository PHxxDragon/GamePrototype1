using GameObjects.Region;
using GameObjects.Target;
using Spawners.SquareSpawners;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.TargetSpawners
{
    public enum InjectKeys
    {
        TopLeft,
        BottomRight
    }
    
    public class TargetSpawnerLifeTimeScope: LifetimeScope
    {
        [SerializeField] private TargetController targetPrefab;
        [SerializeField] private Transform regionTopLeft;
        [SerializeField] private Transform regionBottomRight;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(targetPrefab);
            builder.RegisterEntryPoint<TargetSpawnerController>();
            builder.RegisterInstance(regionTopLeft).Keyed(InjectKeys.TopLeft);
            builder.RegisterInstance(regionBottomRight).Keyed(InjectKeys.BottomRight);
        }
    }
}
