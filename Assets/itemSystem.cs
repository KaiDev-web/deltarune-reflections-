using UnityEngine;
using UnityEngine.InputSystem;

public class itemSystem : MonoBehaviour
{
    [Header("Item")] 
    public Transform itemTarget;
    public string itemName;
    public itemManager manager;
    
    public LayerMask itemLayer;
    public Vector2 lastMoveDirection = Vector2.left;

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(itemTarget.position, lastMoveDirection, 1f, itemLayer);
        {
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                manager.ObtainItem(itemName); 
            }
        }
    }
}
