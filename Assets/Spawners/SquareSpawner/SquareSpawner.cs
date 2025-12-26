using GameObjects.Square;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Spawners.SquareSpawner
{
    public class SquareSpawner : MonoBehaviour
    {
        [SerializeField] private SquareController squarePrefab;

        [SerializeField] private Transform regionTopLeft;

        [SerializeField] private Transform regionBottomRight;

        [Inject]
        public void Construct(GameManager.GameManager gameManager, GameUI gameUI)
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
        }
        
        private GameManager.GameManager _gameManager;
        
        private GameUI _gameUI;

        private float _remainTime;

        private void Start()
        {
            Assert.IsNotNull(squarePrefab);
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
                var squareController = Instantiate(squarePrefab, newPosition, Quaternion.identity);
                squareController.SetGameManager(_gameManager);
                squareController.SetGameUI(_gameUI);
                _gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
