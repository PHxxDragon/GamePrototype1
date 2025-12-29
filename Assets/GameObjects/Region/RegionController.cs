using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.Region
{
    public class RegionController: ITickable
    {
        [Inject]
        public RegionController(
            [Key(InjectKeys.RotateCenter)] Transform rotateCenter, 
            [Key(InjectKeys.RotateSpeed)] float rotateSpeed, 
            Transform transform
        )
        {
            _rotateCenter = rotateCenter;
            _rotateSpeed = rotateSpeed;
            _transform = transform;
        }
        
        private readonly Transform _rotateCenter;
        private readonly float _rotateSpeed;
        private readonly Transform _transform;
        
        public Transform RegionTransform => _transform;

        public float Radius => new Vector2(_transform.localScale.x,  _transform.localScale.y).magnitude / 2;

        public void Tick()
        {
            _transform.RotateAround(_rotateCenter.position, Vector3.back, _rotateSpeed * Time.deltaTime);
        }
    }
}
