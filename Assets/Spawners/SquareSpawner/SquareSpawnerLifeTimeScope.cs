using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawner
{
    public class SquareSpawnerLifeTimeScope : LifetimeScope
    {
        [SerializeField] private LifetimeScope parent;
        [SerializeField] private SquareController squarePrefab;
        [SerializeField] private Transform topLeft;
        [SerializeField] private Transform bottomRight;

        // protected override LifetimeScope FindParent()
        // {
        //     return parent ? parent : base.FindParent();
        // }

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Hello 2 !!!");
            Debug.Log(Parent.gameObject);
            builder.RegisterInstance(squarePrefab);
            builder.RegisterEntryPoint<SquareSpawnerController>();
            builder.RegisterInstance(topLeft).Keyed(InjectKeys.TopLeft);
            builder.RegisterInstance(bottomRight).Keyed(InjectKeys.BottomRight);
        }
    }
}
