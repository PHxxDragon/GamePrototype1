using GameObjects.SquareChild;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.Square
{
    public enum InjectKeys
    {
        RemainHealth,
        ScoreCircle,
        Prefab
    }
    public class SquareLifeTimeScope : LifetimeScope
    {
        [SerializeField] private float remainHealth = 10f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject scoreCircle;
        [SerializeField] private SquareChildController childPrefab;
        [SerializeField] private SquareView squareView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(remainHealth).Keyed(InjectKeys.RemainHealth);
            builder.RegisterInstance(spriteRenderer);
            builder.RegisterInstance(scoreCircle).Keyed(InjectKeys.ScoreCircle);
            builder.RegisterInstance(childPrefab).Keyed(InjectKeys.Prefab);
            builder.RegisterEntryPoint<SquareController>().As<SquareController>();
            builder.RegisterComponent(squareView);
        }
    }
}
