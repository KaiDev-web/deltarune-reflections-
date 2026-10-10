using UnityEngine;

public class CameraEnterTrigger : MonoBehaviour
{
    public cameraSystem1 cameraSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cameraSystem != null)
        {
            cameraSystem.OnTriggerEnter2D(other);
            cameraSystem.enabled = true;
        }   
    }
}
