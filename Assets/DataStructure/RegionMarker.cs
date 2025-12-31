using UnityEngine;

namespace DataStructure
{
    public class RegionMarker : MonoBehaviour
    {
        [SerializeField] private Vector2 localTopLeft = new(-1, 1);
        [SerializeField] private Vector2 localBottomRight = new(1, -1);
        [SerializeField] private Color color = Color.green;
        
        public Vector2 RegionTopLeft => transform.TransformPoint(localTopLeft);
        public Vector2 RegionBottomRight => transform.TransformPoint(localBottomRight);

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Vector2 regionTopLeft = transform.TransformPoint(localTopLeft);
            Vector2 regionBottomRight = transform.TransformPoint(localBottomRight);
            Gizmos.DrawLine(new Vector2(regionTopLeft.x, regionTopLeft.y), new Vector2(regionBottomRight.x, regionTopLeft.y));
            Gizmos.DrawLine(new Vector2(regionBottomRight.x, regionTopLeft.y), new Vector2(regionBottomRight.x, regionBottomRight.y));
            Gizmos.DrawLine(new Vector2(regionBottomRight.x, regionBottomRight.y), new Vector2(regionTopLeft.x, regionBottomRight.y));
            Gizmos.DrawLine(new Vector2(regionTopLeft.x, regionBottomRight.y), new Vector2(regionTopLeft.x, regionTopLeft.y));
        }
    }
}
