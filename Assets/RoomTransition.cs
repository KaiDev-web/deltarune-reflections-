using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public GameObject transitionObject; 
    
    [Header("Sprite Render")]
    public Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collisione attivata");
            FadeIn();
        }
    }

    private void FadeIn()
    {
        if(animator != null) animator.SetTrigger("open");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);

    }

}
