using UnityEngine;
using UnityEngine.InputSystem;

public class krisMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 4f;
    public float currentSpeed;

    private Animator animator;
    private Vector2 lastMoveDirection = Vector2.down;

    public void Start()
    {
        currentSpeed = walkSpeed;

        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        bool isMoving = false;
        Vector2 movementDir = Vector2.zero;
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
            movementDir = Vector2.left;
            isMoving = true;
        }
        else if(Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
            movementDir = Vector2.right;
            isMoving = true;
        }
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
            movementDir = Vector2.up;
            isMoving = true;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
            movementDir = Vector2.down;
            isMoving = true;
        }
        if(Keyboard.current.xKey.isPressed)
        {
            currentSpeed = runSpeed;
        }

        if(isMoving)
        {
            lastMoveDirection = movementDir;
            animator.SetFloat("MoveX", movementDir.x);
            animator.SetFloat("MoveY", movementDir.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            currentSpeed = walkSpeed;
            animator.SetBool("isMoving", false);
        }

        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}
