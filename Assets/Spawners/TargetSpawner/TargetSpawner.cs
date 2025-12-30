using GameManagers;
using GameObjects.Region;
using GameObjects.Target;
using Sisus.Init;
using UnityEngine;
using UnityEngine.Assertions;

namespace Spawners.TargetSpawner
{
    public class TargetSpawner : MonoBehaviour<GameManager>
    {
        [SerializeField] private TargetController targetPrefab;
        [SerializeField] private Transform regionTopLeft;
        [SerializeField] private Transform regionBottomRight;
        [SerializeField] private RegionController regionController;
        
        private GameManager _gameManager;
        private float _remainTime;

        protected override void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Start()
        {
            Assert.IsNotNull(targetPrefab);
            _remainTime = Constants.Constants.TargetSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.TargetSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
                var targetController = Instantiate(targetPrefab, newPosition, Quaternion.identity);
                _gameManager.TargetComponents.Add(targetController);

                if (Vector3.Distance(regionController.transform.position, targetController.transform.position) <
                    regionController.Radius)
                {
                    targetController.transform.parent = regionController.transform;
                }
            }
        }
    }
}
