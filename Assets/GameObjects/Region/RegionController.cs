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
            RegionView regionView
        )
        {
            _rotateCenter = rotateCenter;
            _rotateSpeed = rotateSpeed;
            _regionView = regionView;
        }
        
        private readonly Transform _rotateCenter;
        private readonly float _rotateSpeed;
        private readonly RegionView _regionView;
        
        public Transform RegionTransform => _regionView.transform;

        public float Radius => new Vector2(_regionView.transform.localScale.x,  _regionView.transform.localScale.y).magnitude / 2;

        public void Tick()
        {
            _regionView.transform.RotateAround(_rotateCenter.position, Vector3.back, _rotateSpeed * Time.deltaTime);
        }
    }
}
