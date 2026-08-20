using System.Collections;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class creditsManager : MonoBehaviour
{
    [Header("Art")] 
    public TextMeshProUGUI art;

    [Header("Music")] 
    public TextMeshProUGUI music;

    [Header("Code")] 
    public TextMeshProUGUI code;

    [Header("Playtest")] 
    public TextMeshProUGUI playtest;

    [Header("Story")] 
    public TextMeshProUGUI story;

    public void Start()
    {
        StartCoroutine(CreditsShow());
    }

    private IEnumerator CreditsShow()
    {
        // art
        
        art.gameObject.SetActive(true);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        // music
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(true);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        // code
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(true);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        // story
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(true);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        // playtest
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // end
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        Application.Quit();
    }
}