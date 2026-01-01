using UnityEngine;

namespace GameObjects.RotatePlanets
{
    public class RotateBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject rotateCenter;
        [SerializeField] private float rotateSpeed = 5f;

        private void Update()
        {
            transform.RotateAround(rotateCenter.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }
}
