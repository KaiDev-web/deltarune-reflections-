

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string NameScene;

    private void OnTriggerEnter2D(Collider2D collisione)
    {
        if (collisione.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadSceneAsync(NameScene);
        }
    }
}

