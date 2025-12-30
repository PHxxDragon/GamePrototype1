using GameObjects.SquareChilds;
using UnityEngine;

namespace GameObjects.Squares
{
    public class SquareFactory : MonoBehaviour
    {
        [SerializeField] private SquareController squarePrefab;
        [SerializeField] private SquareChildController squareChildPrefab;

        public SquareController CreateSquare(Vector3 position)
        {
            return Instantiate(squarePrefab, position, Quaternion.identity, transform);
        }

        public SquareChildController CreateSquareChild(Vector3 position)
        {
            return Instantiate(squareChildPrefab, position, Quaternion.identity, transform);
        }
    }
}
