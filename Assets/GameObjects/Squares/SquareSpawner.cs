using GameManagers;
using Sisus.Init;
using UI;
using UnityEngine;

namespace GameObjects.Squares
{
    public class SquareSpawner : MonoBehaviour<GameManager, GameUI, SquareFactory>
    {
        [SerializeField]
        private Transform regionTopLeft;
        
        [SerializeField]
        private Transform regionBottomRight;
        
        private GameManager _gameManager;
        private GameUI _gameUI;
        private SquareFactory _squareFactory;
        private float _remainTime;

        protected override void Init(GameManager gameManager, GameUI gameUI, SquareFactory squareFactory)
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
            _squareFactory = squareFactory;
        }

        private void Start()
        {
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
                var squareController = _squareFactory.CreateSquare(newPosition);
                squareController.transform.position = newPosition;
                _gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
