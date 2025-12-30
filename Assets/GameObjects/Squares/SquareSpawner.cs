using GameModels;
using Sisus.Init;
using UnityEngine;

namespace GameObjects.Squares
{
    public class SquareSpawner : MonoBehaviour<SquareControllerList, SquareFactory>
    {
        [SerializeField]
        private Transform regionTopLeft;
        
        [SerializeField]
        private Transform regionBottomRight;
        
        private SquareControllerList _squareControllerList;
        private SquareFactory _squareFactory;
        private float _remainTime;

        protected override void Init(SquareControllerList squareControllerList, SquareFactory squareFactory)
        {
            _squareControllerList = squareControllerList;
            _squareFactory = squareFactory;
        }

        private void Start()
        {
            _remainTime = Constants.Constants.SquareSpawner.SpawnTime;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0f)
            {
                _remainTime += Constants.Constants.SquareSpawner.SpawnTime;

                Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
                var squareController = _squareFactory.CreateSquare(newPosition);
                squareController.transform.position = newPosition;
                _squareControllerList.SquareComponents.Add(squareController);
            }
        }
    }
}
