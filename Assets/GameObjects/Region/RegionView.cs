using UnityEngine;
using VContainer;

namespace GameObjects.Region
{
    public class RegionView : MonoBehaviour
    {
        private RegionController _regionController;
        
        public RegionController RegionController => _regionController;
    
        [Inject]
        public void Construct(RegionController regionController)
        {
            _regionController = regionController;
        }
    }
}
