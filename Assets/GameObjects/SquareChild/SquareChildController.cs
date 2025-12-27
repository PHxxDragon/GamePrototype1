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
        
        private SquareController parent;
        private GameManager gameManager;
        private GameUI gameUI;

        private float remainGrowUpTime = Constants.Constants.SquareSpawner.GrowUpTime;

        public void SetGameManager(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void SetGameUI(GameUI gameUI)
        {
            this.gameUI = gameUI;
        }

        public void SetParent(SquareController parent)
        {
            this.parent = parent;
        }

        void Update()
        {
            if (parent)
            {
                if (Vector3.Distance(transform.position, parent.transform.position) > 0.1f)
                {
                    Vector3 direction = parent.transform.position - transform.position;
                    transform.position += direction.normalized * (Time.deltaTime * 10f);
                }
                else
                {
                    remainGrowUpTime -= Time.deltaTime;
                }
            }

            if (remainGrowUpTime <= 0)
            {
                for (var i = 0; i < 3; i++)
                {
                    var squareController = squarePrefab.Instantiate(gameManager, gameUI);
                    squareController.transform.position = transform.position;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
