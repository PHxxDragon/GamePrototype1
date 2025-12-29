using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.SquareChild
{
    public class SquareChildLifeTimeScope: LifetimeScope
    {
        [SerializeField] private SquareChildView squareChildView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SquareChildController>().As<SquareChildController>();
            builder.RegisterComponent(squareChildView).As<SquareChildView>();
        }
    }
}