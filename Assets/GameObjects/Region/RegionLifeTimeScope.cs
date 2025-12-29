using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.Region
{
    public enum InjectKeys
    {
        RotateSpeed,
        RotateCenter
    }
    
    public class RegionLifeTimeScope : LifetimeScope
    {
        [SerializeField] private Transform rotateCenter;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private RegionView regionView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(rotateCenter).Keyed(InjectKeys.RotateCenter);
            builder.RegisterInstance(transform);
            builder.RegisterInstance(rotateSpeed).Keyed(InjectKeys.RotateSpeed);
            builder.RegisterEntryPoint<RegionController>().As<RegionController>();
            builder.RegisterComponent(regionView);
        }
    }
}
