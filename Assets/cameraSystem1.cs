using System;
using UnityEngine;

public class cameraSystem1 : MonoBehaviour
{
    [Header("Camera")]
    public Camera cam;

    [Header("Enter")]
    public GameObject enterGameObject;

    public bool isPlayerIn = false;

    public Transform target;

    void Start()
    {
        Debug.Log("Camera Activated");
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
            enabled = false;
        }
    }
    
    private void LateUpdate()
    {
        MoveCamera();
    }
    
    public void MoveCamera()
    {
        if (target != null && cam != null)
        {
            cam.transform.position = new Vector3(target.position.x, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
