using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public GameObject transitionObject; 
    
    [Header("Sprite Render")]
    public SpriteRenderer transition;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collisione attivata");
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("Loading ciclo: Fade In");
        float alphaVal = transition.color.a;
        Color tmp = transition.color;

        while (transition.color.a < 1)
        {
            alphaVal += 0.03f;
            tmp.a = alphaVal;

            transition.color = tmp;

            yield return new WaitForSeconds(0.02f);
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);

    }

}
