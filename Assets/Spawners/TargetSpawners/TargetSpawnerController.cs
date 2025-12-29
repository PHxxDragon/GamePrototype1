using GameManagers;
using GameObjects.Region;
using GameObjects.Target;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;

namespace Spawners.TargetSpawners
{
    public class TargetSpawnerController: IStartable, ITickable
    {
        [Inject]
        public void Construct(
            GameManager gameManager,
            [Key(InjectKeys.TopLeft)] Transform regionTopLeft,
            [Key(InjectKeys.BottomRight)] Transform regionBottomRight,
            TargetController targetPrefab,
            RegionView regionView,
            IObjectResolver resolver
        )
        {
            _gameManager = gameManager;
            _regionTopLeft = regionTopLeft;
            _regionBottomRight = regionBottomRight;
            _targetPrefab = targetPrefab;
            _resolver = resolver;
            _regionView = regionView;
        }
        
        private TargetController _targetPrefab;
        private Transform _regionTopLeft;
        private Transform _regionBottomRight;
        private RegionView _regionView;
        private IObjectResolver _resolver;
        private float _remainTime;
        private GameManager _gameManager;

        public void Start()
        {
            Assert.IsNotNull(_targetPrefab);
            _remainTime = Constants.Constants.TargetSpawner.SpawnTime;
        }

        public void Tick()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.TargetSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(_regionTopLeft.position.x, _regionBottomRight.position.x), Random.Range(_regionTopLeft.position.y, _regionBottomRight.position.y), 0);
                var targetController = _resolver.Instantiate(_targetPrefab, newPosition, Quaternion.identity);
                _gameManager.TargetComponents.Add(targetController);

                if (Vector3.Distance(_regionView.RegionController.RegionTransform.position, targetController.transform.position) <
                    _regionView.RegionController.Radius)
                {
                    targetController.transform.parent = _regionView.RegionController.RegionTransform;
                }
            }
        }
    }
}
