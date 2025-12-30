using UnityEngine;

namespace GameObjects.Targets
{
    public class TargetFactory : MonoBehaviour
    {
        [SerializeField] private TargetController targetPrefab;

        public TargetController CreateTarget(Vector3 position)
        {
            return Instantiate(targetPrefab, position, Quaternion.identity);
        }
    }
}
