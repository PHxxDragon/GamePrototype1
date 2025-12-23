using UnityEngine;

namespace Objects.Region
{
    public class RegionController : MonoBehaviour
    {
        [SerializeField] private Transform rotateCenter;

        [SerializeField] private float rotateSpeed = 30f;

        private void Update()
        {
            transform.RotateAround(rotateCenter.position, Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }
}
