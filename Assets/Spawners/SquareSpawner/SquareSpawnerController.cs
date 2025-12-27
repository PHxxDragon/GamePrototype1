using GameObjects.Square;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawner
{
    public enum InjectKeys
    {
        TopLeft,
        BottomRight
    }
    
    public class SquareSpawnerController: IStartable, ITickable
    {
        [Inject]
        public void Construct(
            GameManager.GameManager gameManager, 
            GameUI gameUI, 
            IObjectResolver resolver, 
            SquareController squarePrefab, 
            [Key(InjectKeys.TopLeft)] Transform regionTopLeft,
            [Key(InjectKeys.BottomRight)] Transform regionBottomRight)
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
            _resolver = resolver;
            _squarePrefab = squarePrefab;
            _regionTopLeft = regionTopLeft;
            _regionBottomRight = regionBottomRight;
        }
        
        private GameManager.GameManager _gameManager;
        
        private GameUI _gameUI;

        private float _remainTime;
        
        private IObjectResolver _resolver;
        
        private SquareController _squarePrefab;
        
        private Transform _regionTopLeft;
        
        private Transform _regionBottomRight;

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
                
                var squareController = _resolver.Instantiate(_squarePrefab, newPosition, Quaternion.identity);
                squareController.SetGameManager(_gameManager);
                squareController.SetGameUI(_gameUI);
                _gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
