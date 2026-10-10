using UnityEngine;
using UnityEngine.InputSystem;

public class interactUp2 : MonoBehaviour
{
    [Header("Dialogue")] 
    public GameObject dialogueSystem;

    [Header("Layer and stuff")] 
    private Vector2 lastMoveDirection = Vector2.up;
    public LayerMask interactLayer;

    public krisMovement movementKr;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMoveDirection, 1.5f, interactLayer);

        if (Keyboard.current.zKey.wasPressedThisFrame && hit.collider != null)
        {
            movementKr.enabled = false;
            dialogueSystem.SetActive(true);
        }
    }
}