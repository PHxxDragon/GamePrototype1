using GameObjects.Square;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Spawners.SquareSpawner
{
    public class SquareSpawner : MonoBehaviour
    {
        [SerializeField] private GameManager.GameManager gameManager;
        [SerializeField] private GameUI gameUI;

        [SerializeField] private SquareController squarePrefab;

        [SerializeField] private Transform regionTopLeft;

        [SerializeField] private Transform regionBottomRight;

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
                squareController.SetGameManager(gameManager);
                squareController.SetGameUI(gameUI);
                gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
