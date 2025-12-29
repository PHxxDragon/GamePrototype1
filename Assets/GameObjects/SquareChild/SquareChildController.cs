using GameObjects.Square;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.SquareChild
{
    public class SquareChildController : ITickable
    {
        
        [Inject]
        public SquareChildController(SquareFactory squareFactory, SquareChildView squareChildView)
        {
            _squareFactory = squareFactory;
            _squareChildView = squareChildView;
        }
        
        private readonly SquareFactory _squareFactory;
        private readonly SquareChildView _squareChildView;
        private SquareView _parent;
        private float _remainGrowUpTime = Constants.Constants.SquareSpawner.GrowUpTime;

        public void SetParent(SquareView parent)
        {
            _parent = parent;
        }

        public void Tick()
        {
            if (_parent)
            {
                if (Vector3.Distance(_squareChildView.transform.position, _parent.transform.position) > 0.1f)
                {
                    Vector3 direction = _parent.transform.position - _squareChildView.transform.position;
                    _squareChildView.transform.position += direction.normalized * (Time.deltaTime * 10f);
                }
                else
                {
                    _remainGrowUpTime -= Time.deltaTime;
                }
            }

            if (_remainGrowUpTime <= 0)
            {
                for (var i = 0; i < 3; i++)
                {
                    _squareFactory.CreateSquare(_squareChildView.transform.position);
                }
                Object.Destroy(_squareChildView.gameObject);
            }
        }
    }
}
