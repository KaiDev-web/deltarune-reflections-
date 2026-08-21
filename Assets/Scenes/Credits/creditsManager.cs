using System.Collections;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class creditsManager : MonoBehaviour
{
    [Header("Game")] 
    public TextMeshProUGUI game;

    [Header("Thanks")] 
    public TextMeshProUGUI thanks;
    
    [Header("Art")] 
    public TextMeshProUGUI art;
    public TextMeshProUGUI otherArt;

    [Header("Music")] 
    public TextMeshProUGUI music;

    [Header("Code")] 
    public TextMeshProUGUI code;

    [Header("Playtest")] 
    public TextMeshProUGUI playtest;
    public TextMeshProUGUI playtest2;

    [Header("Story")] 
    public TextMeshProUGUI story;

    [Header("Traduction IT")] 
    public TextMeshProUGUI italian;

    public void Start()
    {
        StartCoroutine(CreditsShow());
    }

    private IEnumerator CreditsShow()
    {
        // game
        
        game.gameObject.SetActive(true);
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        // art
        
        game.gameObject.SetActive(false);
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
        playtest2.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        // playtest 2
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(true);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);
        
        // other art and it
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(true);
        italian.gameObject.SetActive(true);
        thanks.gameObject.SetActive(false);

        yield return new WaitForSeconds(4.3f);
        
        // thanks
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // end
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        
        Application.Quit();
    }
}