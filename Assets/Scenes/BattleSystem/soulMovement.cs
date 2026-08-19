using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class soulMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 4f;
    public float currentSpeed;
    public attackPatternsEnemies attacks;
    public int damage;
    public healthBar health;
    public healthDownBar health2;

    [Header("Audio")]
    public AudioSource sndCollide;
    public bool isPlaying;

    public void Start()
    {
        currentSpeed = walkSpeed;
        isPlaying = false;

    }

    public void Update()
    {
        Vector2 movementDir = Vector2.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
            movementDir = Vector2.left;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
            movementDir = Vector2.right;
        }
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
            movementDir = Vector2.up;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
            movementDir = Vector2.down;
        }
        if (Keyboard.current.xKey.isPressed)
        {
            currentSpeed = runSpeed;
        }
    }

    public void DamageAll(int damage)
    {
        if (health != null) health.Damage(damage);
        if (health2 != null) health2.Damage(damage);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlaying == false && collision.CompareTag("Attack"))
        {
            StartCoroutine(PlaySound());
            DamageAll(damage);
        }

        if (health.health == 0 || health2.health <= 0)
        {
            health.Dead();
        }
    }

    public IEnumerator PlaySound()
    {
        sndCollide.Play();
        isPlaying = true;
        yield return new WaitForSeconds(2.2f);
        isPlaying = false;
    }
}
