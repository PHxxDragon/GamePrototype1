using GameManagers;
using GameObjects.Region;
using GameObjects.Target;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Spawners.TargetSpawner
{
    public class TargetSpawner : MonoBehaviour
    {
        [SerializeField] private TargetController targetPrefab;

        [SerializeField] private Transform regionTopLeft;

        [SerializeField] private Transform regionBottomRight;
        [SerializeField] private RegionController regionController;

        private float _remainTime;
    
        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private GameManager _gameManager;

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
