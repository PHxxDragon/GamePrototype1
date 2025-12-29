using UnityEngine;
using VContainer;

namespace GameObjects.SquareChild
{
    public class SquareChildView: MonoBehaviour
    {
        private IObjectResolver _objectResolver;
        private SquareChildController _squareChildController;
        public SquareChildController SquareChildController => _squareChildController ?? _objectResolver.Resolve<SquareChildController>();

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }

        private void Start()
        {
            _squareChildController = _objectResolver.Resolve<SquareChildController>();
        }
    }
}