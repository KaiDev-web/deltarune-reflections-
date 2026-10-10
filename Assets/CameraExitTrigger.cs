using UnityEngine;

public class CameraExitTrigger : MonoBehaviour
{
    public cameraSystem1 cameraSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cameraSystem != null)
        {
            cameraSystem.OnTriggerExit2D(other);
        }   
    }
}