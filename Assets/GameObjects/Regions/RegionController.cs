using UnityEngine;

namespace GameObjects.Regions
{
    public class RegionController : MonoBehaviour
    {
        [SerializeField]
        private Transform rotateCenter;

        [SerializeField]
        private float rotateSpeed;

        public float Radius => new Vector2(transform.localScale.x,  transform.localScale.y).magnitude / 2;

        private bool _isMoving;
        private float _moveTime = 10f;

        private void Update()
        {
            if (_isMoving) transform.RotateAround(rotateCenter.position, Vector3.back, rotateSpeed * Time.deltaTime);
            
            _moveTime -= Time.deltaTime;
            if (_moveTime <= 0f)
            {
                _isMoving = !_isMoving;
                _moveTime = _isMoving ? 10f : 2f;
            }
        }
    }
}
