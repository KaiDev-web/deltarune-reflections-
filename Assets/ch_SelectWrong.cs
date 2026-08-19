using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class ch_SelectWrong : MonoBehaviour
{
    public Image ch6_heart;
    public Image ch5_heart;
    public Image ch4_heart;
    public Image ch3_heart;
    public Image ch2_heart;
    public Image ch1_heart;
    public AudioSource selectWrong;

    public void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame && ch6_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("You shouldn't done this.");
            Application.Quit();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && ch5_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Can't open that either.");
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && ch4_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Can't Open That.");
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && ch3_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Can't open that either.");
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && ch2_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Can't Open That.");
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && ch1_heart.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Can't open that either.");
        }
    }

    public void PlaySound()
    {
        if(selectWrong != null)
        {
            selectWrong.Play();
        }
    }
}

