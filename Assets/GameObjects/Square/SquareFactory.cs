using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.Square
{
    public class SquareFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly SquareView _squarePrefab;
        private readonly LifetimeScope _parentScope;
        
        [Inject]
        public SquareFactory(IObjectResolver resolver, [Key(GameManagers.InjectKeys.Prefab)] SquareView squarePrefab, LifetimeScope parentScope)
        {
            _resolver = resolver;
            _squarePrefab = squarePrefab;
            _parentScope = parentScope;
        }

        public SquareView CreateSquare(Vector3 position)
        {
            using (LifetimeScope.EnqueueParent(_parentScope))
            {
                return _resolver.Instantiate(_squarePrefab, position, Quaternion.identity);
            }
        }
    }
}