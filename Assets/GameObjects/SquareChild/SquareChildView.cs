using UnityEngine;
using VContainer;

namespace GameObjects.SquareChild
{
    public class SquareChildView: MonoBehaviour
    {
        private IObjectResolver _objectResolver;
        
        public SquareChildController SquareChildController { get; private set; }

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }

        private void Start()
        {
            SquareChildController = _objectResolver.Resolve<SquareChildController>();
        }
    }
}