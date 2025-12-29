using GameManagers;
using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawners
{
    public class SquareSpawnerController: IStartable, ITickable
    {
        [Inject]
        public void Construct(
            GameManager gameManager, 
            IObjectResolver resolver, 
            SquareView squarePrefab, 
            [Key(InjectKeys.TopLeft)] Transform regionTopLeft,
            [Key(InjectKeys.BottomRight)] Transform regionBottomRight,
            LifetimeScope currentScope
        )
        {
            _gameManager = gameManager;
            _resolver = resolver;
            _squarePrefab = squarePrefab;
            _regionTopLeft = regionTopLeft;
            _regionBottomRight = regionBottomRight;
            _currentScope = currentScope;
        }
        
        private GameManager _gameManager;
        private float _remainTime;
        private IObjectResolver _resolver;
        private SquareView _squarePrefab;
        private Transform _regionTopLeft;
        private Transform _regionBottomRight;
        private LifetimeScope _currentScope;

        public void Start()
        {
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        public void Tick()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(_regionTopLeft.position.x, _regionBottomRight.position.x), Random.Range(_regionTopLeft.position.y, _regionBottomRight.position.y), 0);
            
                using (LifetimeScope.EnqueueParent(_currentScope))
                {
                    var squareView = _resolver.Instantiate(_squarePrefab, newPosition, Quaternion.identity);
                    _gameManager.SquareComponents.Add(squareView.SquareController);
                }
            }
        }
    }
}
