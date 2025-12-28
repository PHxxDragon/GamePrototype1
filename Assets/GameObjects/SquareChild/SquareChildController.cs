using GameObjects.Square;
using UI;
using UnityEngine;

namespace GameObjects.SquareChild
{
    public class SquareChildController : MonoBehaviour
    {
        [SerializeField] private SquareController squarePrefab;
        
        private SquareController _parent;
        private GameManagers.GameManager _gameManager;
        private GameUI _gameUI;

        private float _remainGrowUpTime = Constants.Constants.SquareSpawner.GrowUpTime;

        public void SetGameManager(GameManagers.GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void SetGameUI(GameUI gameUI)
        {
            _gameUI = gameUI;
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
                    var squareController = Instantiate(squarePrefab, transform.position, Quaternion.identity);
                    squareController.SetGameManager(_gameManager);
                    squareController.SetGameUI(_gameUI);
                }
                
                Destroy(gameObject);
            }
        }
    }
}
