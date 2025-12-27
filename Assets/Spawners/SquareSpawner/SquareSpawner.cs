using GameManagers;
using GameObjects.Square;
using Sisus.Init;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Spawners.SquareSpawner
{
    public class SquareSpawner : MonoBehaviour<GameManager, GameUI, Transform, Transform, SquareController>
    {
        private SquareController _squarePrefab;
        private Transform _regionTopLeft;
        private Transform _regionBottomRight;
        private GameManager _gameManager;
        private GameUI _gameUI;
        private float _remainTime;

        protected override void Init(GameManager gameManager, GameUI gameUI, Transform topLeft, Transform bottomRight, SquareController squareController)
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
            _regionTopLeft = topLeft;
            _regionBottomRight = bottomRight;
            _squarePrefab = squareController;
        }

        private void Start()
        {
            Assert.IsNotNull(_squarePrefab);
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(_regionTopLeft.position.x, _regionBottomRight.position.x), Random.Range(_regionTopLeft.position.y, _regionBottomRight.position.y), 0);
                var squareController = _squarePrefab.Instantiate(_gameManager, _gameUI);
                squareController.transform.position = newPosition;
                _gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
