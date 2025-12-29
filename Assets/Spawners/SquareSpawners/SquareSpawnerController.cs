using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Spawners.SquareSpawners
{
    public class SquareSpawnerController: IStartable, ITickable
    {
        [Inject]
        public void Construct(
            [Key(InjectKeys.TopLeft)] Transform regionTopLeft,
            [Key(InjectKeys.BottomRight)] Transform regionBottomRight,
            SquareFactory squareFactory
        )
        {
            _regionTopLeft = regionTopLeft;
            _regionBottomRight = regionBottomRight;
            _squareFactory = squareFactory;
        }
        
        private float _remainTime;
        private Transform _regionTopLeft;
        private Transform _regionBottomRight;
        private SquareFactory _squareFactory;

        public void Start()
        {
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        public void Tick()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(_regionTopLeft.position.x, _regionBottomRight.position.x), Random.Range(_regionTopLeft.position.y, _regionBottomRight.position.y), 0);
                _squareFactory.CreateSquare(newPosition);
            }
        }
    }
}
