using UnityEngine;
using VContainer;

namespace GameObjects.Region
{
    public class RegionView : MonoBehaviour
    {
        private RegionController _regionController;
        private IObjectResolver _objectResolver;
        
        public RegionController RegionController => _objectResolver.Resolve<RegionController>();
    
        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }
    }
}
