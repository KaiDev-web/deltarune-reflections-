using System.Collections;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class creditsManager : MonoBehaviour
{
    [Header("Gift")]
    // insert chapter7_sideb
    
    [Header("Secret Boss")]
    // testo con scritto (????)
    
    [Header("Final Cutscene")]
    // cutscene 

    [Header("Character")]
    public TextMeshProUGUI characters;
    
    [Header("Made In")]
    public TextMeshProUGUI used;

    public Image unityEngine;

    [Header("DR Credits")]
    public TextMeshProUGUI deltarune;

    [Header("Management")] 
    public TextMeshProUGUI management;
    
    [Header("Reflections by")]
    public TextMeshProUGUI refb; // Reflections by ...

    [Header("Lab Tilemap")] 
    public TextMeshProUGUI labTile;

    [Header("Video Editor")] 
    public TextMeshProUGUI videoEditor;

    [Header("Trailer Gameplay")] 
    public TextMeshProUGUI trailerGameplay;
    
    [Header("Website")] 
    public TextMeshProUGUI website1;

    public TextMeshProUGUI website2;

    [Header("Sketches")] 
    public TextMeshProUGUI sketches;

    [Header("Boss")] 
    public TextMeshProUGUI boss1;
    public TextMeshProUGUI boss2;
    public TextMeshProUGUI boss3;
    
    [Header("")]
    
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
        website1.gameObject.SetActive(false);
        website2.gameObject.SetActive(false);

        yield return new WaitForSeconds(4.3f);
        
        // website
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);
        website1.gameObject.SetActive(true);
        website2.gameObject.SetActive(true);
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);

        yield return new WaitForSeconds(3.2f);
        
        // Boss
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);
        website1.gameObject.SetActive(false);
        website2.gameObject.SetActive(false);
        boss1.gameObject.SetActive(true);
        boss2.gameObject.SetActive(true);
        boss3.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);
        
                
        // deltarune
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // lab tilemap
        
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        labTile.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.7f);
        
        // video editor
        
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        labTile.gameObject.SetActive(false);
        videoEditor.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // trailer gameplay
        
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(false);
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        videoEditor.gameObject.SetActive(true);
        trailerGameplay.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // reflections by ..
        
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        videoEditor.gameObject.SetActive(false);
        trailerGameplay.gameObject.SetActive(false);
        refb.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);
        
        // characters
        
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        videoEditor.gameObject.SetActive(false);
        trailerGameplay.gameObject.SetActive(false);
        refb.gameObject.SetActive(false);
        characters.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // made in
        
        boss3.gameObject.SetActive(false);
        deltarune.gameObject.SetActive(false);
        videoEditor.gameObject.SetActive(false);
        trailerGameplay.gameObject.SetActive(false);
        refb.gameObject.SetActive(false);
        characters.gameObject.SetActive(false);
        used.gameObject.SetActive(true);
        unityEngine.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        // thanks
        
        art.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        code.gameObject.SetActive(false);
        playtest.gameObject.SetActive(false);
        playtest2.gameObject.SetActive(false);
        otherArt.gameObject.SetActive(false);
        italian.gameObject.SetActive(false);
        thanks.gameObject.SetActive(true);
        boss1.gameObject.SetActive(false);
        boss2.gameObject.SetActive(false);
        boss3.gameObject.SetActive(false);
        refb.gameObject.SetActive(false);
        used.gameObject.SetActive(false);
        unityEngine.gameObject.SetActive(false);

        yield return new WaitForSeconds(2.5f);
        
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