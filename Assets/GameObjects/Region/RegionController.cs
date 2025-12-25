using UnityEngine;

namespace GameObjects.Region
{
    public class RegionController : MonoBehaviour
    {
        [SerializeField] private Transform rotateCenter;

        [SerializeField] private float rotateSpeed = 30f;

        public float Radius => new Vector2(transform.localScale.x,  transform.localScale.y).magnitude / 2;

        private void Update()
        {
            transform.RotateAround(rotateCenter.position, Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }
}
