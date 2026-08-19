using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ch7_loadUp : MonoBehaviour
{
    public Button loadUp;
    public Image Transition;

    public float waitToTransition = 3f;

    public void Start()
    {
        Transition.gameObject.SetActive(false);
        loadUp.onClick.AddListener(openMenu);
    }

    public void openMenu()
    {
        Debug.Log("Button Pressed. Loading Coroutine");
        StartCoroutine(TransitionToRoom());
    }

    private IEnumerator TransitionToRoom()
    {
        Transition.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitToTransition);

        SceneManager.LoadScene(1);
    }
}
