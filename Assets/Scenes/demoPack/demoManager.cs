using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class demoManager : MonoBehaviour
{
    [Header("Animator")] 
    public Animator loadScene;

    public string sceneName;

    void Start()
    {
        if(loadScene != null) loadScene.SetTrigger("idle");
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            loadScene.SetTrigger("load");
            StartCoroutine(WaitMe());
        }
    }

    public IEnumerator WaitMe()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneName);
    }
}
