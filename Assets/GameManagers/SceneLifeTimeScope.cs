using UI;
using VContainer;
using VContainer.Unity;

namespace GameManagers
{
    public class SceneLifeTimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GameUI>();
        }
    }
}
