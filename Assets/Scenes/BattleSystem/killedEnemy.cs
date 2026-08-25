using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class killedEnemy : MonoBehaviour
{
    [Header("Description Battle")] 
    public TextMeshProUGUI descBattle;
    public GameObject battleBox;
    public GameObject soul;
    public soulMovement soulScript;

    public AudioSource battleMusic;
    public AudioSource levelUp;
    public attackPatternsEnemies system;

    public battleSystem kris;
    public battleSystemNoelle noelle;
        
    [Tooltip("Health")] 
    public EnemyhealthBar enemy;
    
    [Header("Lost")] 
    public TextMeshProUGUI lost;

    [Header("Killed")] 
    public TextMeshProUGUI killed;

    [Header("Spared")] 
    public TextMeshProUGUI spared;
    
    [Header("TextType")]
    public TextMeshProUGUI textComponentLost;
    public TextMeshProUGUI textComponentKilled;
    public TextMeshProUGUI textComponentSpared;
    public string[] linesL;
    public string[] linesK;
    public string[] linesS;
    public float textSpeed = 0.02f;

    private int indexLost;
    private int indexKilled;
    private int indexSpared;

    
    public void LostEnemy()
    {
        StopMusic();
        PlayAudio();
        system.StopAllCoroutines();
        system.enabled = false;
        kris.enabled = false;
        noelle.enabled = false;
        descBattle.gameObject.SetActive(false);
        lost.gameObject.SetActive(true);
        battleBox.gameObject.SetActive(false);
        soul.gameObject.SetActive(false);
        soulScript.enabled = false;
        StartCoroutine(TypeLineLost());
    }
    
    public void KilledEnemy()
    {
        StopMusic();
        PlayAudio();
        system.StopAllCoroutines();
        system.enabled = false;
        kris.enabled = false;
        noelle.enabled = false;
        descBattle.gameObject.SetActive(false);
        killed.gameObject.SetActive(true);
        battleBox.gameObject.SetActive(false);
        soul.gameObject.SetActive(false);
        soulScript.enabled = false;
        
        StartCoroutine(TypeLineKilled());
    }
    
    public void SparedEnemy()
    {
        StopMusic();
        PlayAudio();
        system.StopAllCoroutines();
        system.enabled = false;
        kris.enabled = false;
        noelle.enabled = false;
        descBattle.gameObject.SetActive(false);
        spared.gameObject.SetActive(true);
        battleBox.gameObject.SetActive(false);
        soul.gameObject.SetActive(false);
        soulScript.enabled = false;
        StartCoroutine(TypeLineSpared());
    }

    public void StopMusic()
    {
        battleMusic.Stop();
    }

    public void PlayAudio()
    {
        levelUp.Play();
    }
    
    private IEnumerator TypeLineLost()
    {
        textComponentLost.text = string.Empty;

        foreach (char c in linesL[indexLost].ToCharArray())
        {
            textComponentLost.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(1.2f);
        string lastScene = PlayerPrefs.GetString("PreviousScene");
        Debug.LogWarning("Loading lastScene");
        SceneManager.LoadSceneAsync(lastScene);
    }
    
    private IEnumerator TypeLineKilled()
    {
        textComponentKilled.text = string.Empty;

        foreach (char c in linesK[indexKilled].ToCharArray())
        {
            textComponentKilled.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        yield return new WaitForSeconds(1.2f);
        string lastScene = PlayerPrefs.GetString("PreviousScene");
        Debug.LogWarning("Loading lastScene");
        SceneManager.LoadSceneAsync(lastScene);
    }
    
    private IEnumerator TypeLineSpared()
    {
        textComponentSpared.text = string.Empty;

        foreach (char c in linesS[indexSpared].ToCharArray())
        {
            textComponentSpared.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

}
