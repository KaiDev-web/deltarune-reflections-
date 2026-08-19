using UnityEngine;

public class DeltaruneCamera : MonoBehaviour
{
    [Header("Target & Speed")]
    public Transform target;
    public float smoothTime = 0.15f;

    [Header("Confini Stanza (Opzionale)")]
    public Collider2D boundsCollider;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    private float targetZ; 

    private void Awake()
    {
        cam = GetComponent<Camera>();
        
        targetZ = transform.position.z;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, targetZ);

        if (boundsCollider != null)
        {
            float vertExtent = cam.orthographicSize;
            float horizExtent = vertExtent * cam.aspect;

            Bounds bounds = boundsCollider.bounds;

            if (bounds.size.x >= horizExtent * 2f)
            {
                float minX = bounds.min.x + horizExtent;
                float maxX = bounds.max.x - horizExtent;
                targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            }
            else
            {
                targetPosition.x = bounds.center.x;
            }

            if (bounds.size.y >= vertExtent * 2f)
            {
                float minY = bounds.min.y + vertExtent;
                float maxY = bounds.max.y - vertExtent;
                targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
            }
            else
            {
                targetPosition.y = bounds.center.y;
            }
        }

        Vector3 newPos = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        newPos.z = targetZ;

        transform.position = newPos;
    }
}