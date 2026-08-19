using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuittingApplication : MonoBehaviour
{
    public TextMeshProUGUI quittingText;
    public float pressWaitTime = 3f;
    private Coroutine coroutine;

    public void Start()
    {
        quittingText.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            coroutine = StartCoroutine(HoldKey());
        }

        if(Keyboard.current.escapeKey.wasReleasedThisFrame)
        {
            StopCoroutine(HoldKey());
            quittingText.gameObject.SetActive(false);
        }
    }

     IEnumerator HoldKey()
    {
        yield return new WaitForSeconds(pressWaitTime);
        quittingText.gameObject.SetActive(true);
        Debug.Log("Application Quitted");
        Application.Quit();
    }
}
