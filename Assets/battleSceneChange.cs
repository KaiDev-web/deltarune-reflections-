using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("Savesystem")]
    public string keyX = ("Savepoint X");

    public string keyY = ("Savepoint Y");
    
    public string NameScene;
    public AudioSource enemyApproaching;
    
    
    [Header("Persistence")]
    public string triggerID = "enemy";

    private void Start()
    {
        if (PlayerPrefs.GetInt(triggerID, 0) == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisione)
    {
        if (collisione.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            StartCoroutine(OpenBattleScene());
        }
    }

    private IEnumerator OpenBattleScene()
    {
        PlaySound();
        yield return new WaitForSeconds(0.4f);
        PlayerPrefs.SetFloat(keyX, transform.position.x);
        PlayerPrefs.SetFloat(keyY, transform.position.y);

        PlayerPrefs.Save();
        
        PlayerPrefs.SetInt(triggerID, 1);
        PlayerPrefs.Save();
        
        SceneManager.LoadSceneAsync(NameScene);
        
    }
    

    private void PlaySound()
    {
        enemyApproaching.Play();
    }
}

