using DataStructure;
using GameModels;
using GameObjects.Regions;
using Sisus.Init;
using UnityEngine;

namespace GameObjects.Targets
{
    public class TargetSpawner : MonoBehaviour<TargetControllerList, TargetFactory>
    {
        [SerializeField] private RegionMarker regionMarker;
        [SerializeField] private RegionController regionController;
        
        private TargetControllerList _targetControllerList;
        private TargetFactory _targetFactory;
        private float _remainTime;

        protected override void Init(TargetControllerList targetControllerList, TargetFactory targetFactory)
        {
            _targetControllerList = targetControllerList;
            _targetFactory = targetFactory;
        }

        private void Start()
        {
            _remainTime = Constants.Constants.TargetSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.TargetSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionMarker.RegionTopLeft.x, regionMarker.RegionBottomRight.x), Random.Range(regionMarker.RegionTopLeft.y, regionMarker.RegionBottomRight.y), 0);
                var targetController = _targetFactory.CreateTarget(newPosition);
                _targetControllerList.TargetComponents.Add(targetController);

                if (Vector3.Distance(regionController.transform.position, targetController.transform.position) <
                    regionController.Radius)
                {
                    targetController.transform.parent = regionController.transform;
                }
            }
        }
    }
}
