using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ch7_select : MonoBehaviour
{
    public TextMeshProUGUI play;
    public TextMeshProUGUI doNot;

    public Image chPlay;
    public Image chDoNot; 
    public Image chSelect_quit;
    public Image ch7_heart;
    public Image ch6_heart;
    public Image ch5_heart;
    public Image ch4_heart;
    public Image ch3_heart;
    public Image ch2_heart;
    public Image ch1_heart;

    public AudioSource selectAudio;

    public void Start()
    {
        play.gameObject.SetActive(false);
        doNot.gameObject.SetActive(false);
        chPlay.gameObject.SetActive(false);
        chDoNot.gameObject.SetActive(false);
        chSelect_quit.gameObject.SetActive(false);
        ch7_heart.gameObject.SetActive(true);
        ch6_heart.gameObject.SetActive(false);
        ch5_heart.gameObject.SetActive(false);
        ch4_heart.gameObject.SetActive(false);
        ch3_heart.gameObject.SetActive(false);
        ch2_heart.gameObject.SetActive(false);
        ch1_heart.gameObject.SetActive(false);

    }

    public void Update()
    {
        // Chapter 7
        if (Keyboard.current.zKey.wasPressedThisFrame && ch7_heart.gameObject.activeSelf)
        {
            ch7_heart.gameObject.SetActive(false);
            chPlay.gameObject.SetActive(true);
            play.gameObject.SetActive(true);
            doNot.gameObject.SetActive(true);
            chDoNot.gameObject.SetActive(false);
            PlaySound();    
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && chPlay.gameObject.activeSelf)
        {
            SceneManager.LoadScene(2);
            PlaySound();
            Debug.Log("Launching CHAPTER 7");
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && chPlay.gameObject.activeSelf)
        {
            chDoNot.gameObject.SetActive(true);
            chPlay.gameObject.SetActive(false);
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && chDoNot.gameObject.activeSelf)
        {
            ch7_heart.gameObject.SetActive(true);
            chPlay.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            doNot.gameObject.SetActive(false);
            chDoNot.gameObject.SetActive(false);
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && chDoNot.gameObject.activeSelf)
        {
            chPlay.gameObject.SetActive(true);
            chDoNot.gameObject.SetActive(false);
            PlaySound();
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && ch7_heart.gameObject.activeSelf)
        {
            ch7_heart.gameObject.SetActive(false);
            ch6_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if(Keyboard.current.downArrowKey.wasPressedThisFrame && ch7_heart.gameObject.activeSelf)
        {
            ch7_heart.gameObject.SetActive(false);
            chSelect_quit.gameObject.SetActive(true);
            PlaySound();
        }
        else if(Keyboard.current.zKey.wasPressedThisFrame && chSelect_quit.gameObject.activeSelf)
        {
            PlaySound();
            Debug.Log("Apllication Aborted");
            Application.Quit();
        }
        else if(Keyboard.current.upArrowKey.wasPressedThisFrame && chSelect_quit.gameObject.activeSelf)
        {
            chSelect_quit.gameObject.SetActive(false);
            ch7_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if (ch6_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch6_heart.gameObject.SetActive(false);
            ch7_heart.gameObject.SetActive(true);
            PlaySound();
        }
        // Chapter 6
        else if(ch6_heart.gameObject.activeSelf && Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ch6_heart.gameObject.SetActive(false);
            ch5_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if(ch5_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch5_heart.gameObject.SetActive(false);
            ch6_heart.gameObject.SetActive(true);
            PlaySound();
        }
        // Chapter 5
        else if(ch5_heart.gameObject.activeSelf && Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ch5_heart.gameObject.SetActive(false);
            ch4_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if (ch4_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch5_heart.gameObject.SetActive(true);
            ch4_heart.gameObject.SetActive(false);
            PlaySound();
        }
        // Chapter 4
        else if (ch4_heart.gameObject.activeSelf && Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ch4_heart.gameObject.SetActive(false);
            ch3_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if (ch3_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch4_heart.gameObject.SetActive(true);
            ch3_heart.gameObject.SetActive(false);
            PlaySound();
        }
        // Chapter 3
        else if (ch3_heart.gameObject.activeSelf && Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ch3_heart.gameObject.SetActive(false);
            ch2_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if (ch2_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch3_heart.gameObject.SetActive(true);
            ch2_heart.gameObject.SetActive(false);
            PlaySound();
        }
        // Chapter 2
        else if (ch2_heart.gameObject.activeSelf && Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            ch2_heart.gameObject.SetActive(false);
            ch1_heart.gameObject.SetActive(true);
            PlaySound();
        }
        else if (ch1_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            ch2_heart.gameObject.SetActive(true);
            ch1_heart.gameObject.SetActive(false);
            PlaySound();
        }

    }

    void PlaySound()
    {
        if (selectAudio != null)
            selectAudio.Play();
    }
}