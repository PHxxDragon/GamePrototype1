using GameManagers;
using GameObjects.Square;
using Sisus.Init;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Spawners.SquareSpawner
{
    public class SquareSpawner : MonoBehaviour<GameManager, GameUI>
    {
        [SerializeField] private SquareController squarePrefab;

        [SerializeField] private Transform regionTopLeft;

        [SerializeField] private Transform regionBottomRight;

        private GameManager gameManager;
        private GameUI gameUI;
        private float remainTime;

        protected override void Init(GameManager pgameManager, GameUI pgameUI)
        {
            gameManager = pgameManager;
            gameUI = pgameUI;
        }

        private void Start()
        {
            Assert.IsNotNull(squarePrefab);
            remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        private void Update()
        {
            remainTime -= Time.deltaTime;
            if (remainTime <= 0f)
            {
                remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
                var squareController = squarePrefab.Instantiate(gameManager, gameUI);
                squareController.transform.position = newPosition;
                gameManager.SquareComponents.Add(squareController);
            }
        }
    }
}
