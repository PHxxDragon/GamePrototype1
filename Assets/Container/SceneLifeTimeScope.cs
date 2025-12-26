using UI;
using VContainer;
using VContainer.Unity;

namespace Container
{
    public class SceneLifeTimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager.GameManager>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GameUI>();
        }
    }
}
