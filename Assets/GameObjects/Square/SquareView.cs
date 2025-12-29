using UnityEngine;
using VContainer;

namespace GameObjects.Square
{
    public class SquareView : MonoBehaviour
    {
        private IObjectResolver _objectResolver;
        
        public SquareController SquareController { get; private set; }

        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }

        private void Start()
        {
            SquareController = _objectResolver.Resolve<SquareController>();
        }
    }
}
