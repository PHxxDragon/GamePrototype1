using UnityEngine;
using VContainer;

namespace GameObjects.Region
{
    public class RegionView : MonoBehaviour
    {
        private IObjectResolver _objectResolver;
        
        public RegionController RegionController { get; private set; }

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }

        private void Start()
        {
            RegionController = _objectResolver.Resolve<RegionController>();
        }
    }
}
