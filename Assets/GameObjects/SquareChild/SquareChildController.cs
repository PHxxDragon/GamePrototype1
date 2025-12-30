using GameObjects.Square;
using Sisus.Init;
using UnityEngine;

namespace GameObjects.SquareChild
{
    public class SquareChildController : MonoBehaviour<SquareFactory>
    {
        private SquareController _parent;
        private SquareFactory _squareFactory;
        private float _remainGrowUpTime = Constants.Constants.SquareSpawner.GrowUpTime;
        
        protected override void Init(SquareFactory squareFactory)
        {
            _squareFactory = squareFactory;
        }

        public void SetParent(SquareController parent)
        {
            _parent = parent;
        }

        void Update()
        {
            if (_parent)
            {
                if (Vector3.Distance(transform.position, _parent.transform.position) > 0.1f)
                {
                    Vector3 direction = _parent.transform.position - transform.position;
                    transform.position += direction.normalized * (Time.deltaTime * 10f);
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
                    _squareFactory.CreateSquare(transform.position);
                }
                
                Destroy(gameObject);
            }
        }
    }
}
