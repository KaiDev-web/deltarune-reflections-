using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DownBarManager : MonoBehaviour
{
    public Button quitButton;
    public TextMeshProUGUI copyrightText;

    void Start()
    {
        ShowButtons();

        quitButton.onClick.AddListener(OnQuitButtonPress);
    }

    void OnQuitButtonPress()
    {
        Debug.Log("Application Quitted");
        Application.Quit();
    }


    void ShowButtons()
    {
        quitButton.gameObject.SetActive(true);
        copyrightText.gameObject.SetActive(true);
    }
}
