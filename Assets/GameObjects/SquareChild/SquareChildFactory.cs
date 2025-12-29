using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.SquareChild
{
    public class SquareChildFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly SquareChildView _squareChildPrefab;
        private readonly LifetimeScope _parentScope;
        
        [Inject]
        public SquareChildFactory(IObjectResolver resolver, [Key(GameManagers.InjectKeys.Prefab)] SquareChildView squareChildPrefab, LifetimeScope parentScope)
        {
            _resolver = resolver;
            _squareChildPrefab = squareChildPrefab;
            _parentScope = parentScope;
        }

        public SquareChildView CreateSquareChild(Vector3 position)
        {
            using (LifetimeScope.EnqueueParent(_parentScope))
            {
                return _resolver.Instantiate(_squareChildPrefab, position, Quaternion.identity);
            }
        }
    }
}