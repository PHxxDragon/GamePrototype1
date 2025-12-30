using GameManagers;
using GameObjects.Square;
using Sisus.Init;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace Spawners.SquareSpawner
{
    public class SquareSpawner : MonoBehaviour<GameManager, GameUI>
    {
        [SerializeField]
        private Transform regionTopLeft;
        
        [SerializeField]
        private Transform regionBottomRight;
        
        [SerializeField]
        private SquareController squarePrefab;
        
        private GameManager _gameManager;
        private GameUI _gameUI;
        private float _remainTime;

        protected override void Init(GameManager gameManager, GameUI gameUI)
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
        }

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
                var squareController = squarePrefab.Instantiate(_gameManager, _gameUI);
                squareController.transform.position = newPosition;
                _gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
