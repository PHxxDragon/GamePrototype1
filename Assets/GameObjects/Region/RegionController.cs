using Sisus.Init;
using UnityEngine;

namespace GameObjects.Region
{
    public class RegionController : MonoBehaviour<Transform, float>
    {
        private Transform _rotateCenter;

        private float _rotateSpeed;
        
        protected override void Init(Transform firstArgument, float secondArgument)
        {
            _rotateCenter = firstArgument;
            _rotateSpeed = secondArgument;
        }

        public float Radius => new Vector2(transform.localScale.x,  transform.localScale.y).magnitude / 2;

        private void Update()
        {
            transform.RotateAround(_rotateCenter.position, Vector3.back, _rotateSpeed * Time.deltaTime);
        }
    }
}
