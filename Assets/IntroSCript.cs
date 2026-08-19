using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SaveFileSelection : MonoBehaviour
{
    public Button savefile1;
    public Button savefile2;
    public Button savefile3;

    public Image Transition;

    public float waitToTransition = 3f;

    public void Start()
    {
        Transition.gameObject.SetActive(false);
    }

    public void SelectSaveFile(int slotNumber)
    {
        Debug.Log("Loading Save File " + slotNumber);

        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        Transition.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitToTransition);
        SceneManager.LoadScene(1);
    }
}