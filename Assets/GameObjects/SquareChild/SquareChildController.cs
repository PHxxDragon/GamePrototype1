using GameManagers;
using GameObjects.Square;
using UI;
using UnityEngine;
using Sisus.Init;

namespace GameObjects.SquareChild
{
    public class SquareChildController : MonoBehaviour
    {
        [SerializeField] private SquareController squarePrefab;
        
        private SquareController _parent;

        private float _remainGrowUpTime = Constants.Constants.SquareSpawner.GrowUpTime;

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
                    var squareController = Instantiate(squarePrefab);
                    squareController.transform.position = transform.position;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
