using VContainer;
using VContainer.Unity;

namespace Container
{
    public class GameLiftTimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager.GameManager>(Lifetime.Singleton);
        }
    }
}
