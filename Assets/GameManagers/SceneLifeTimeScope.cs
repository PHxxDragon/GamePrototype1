using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameManagers
{
    public class SceneLifeTimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Hello!!!");
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GameUI>();
        }
    }
}
