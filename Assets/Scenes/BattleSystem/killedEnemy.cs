using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class killedEnemy : MonoBehaviour
{
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
        lost.gameObject.SetActive(true);
        StartCoroutine(TypeLineLost());
    }
    
    public void KilledEnemy()
    {
        killed.gameObject.SetActive(true);
        StartCoroutine(TypeLineKilled());
    }
    
    public void SparedEnemy()
    {
        spared.gameObject.SetActive(true);
        StartCoroutine(TypeLineSpared());
    }
    
    private IEnumerator TypeLineLost()
    {
        textComponentLost.text = string.Empty;

        foreach (char c in linesL[indexLost].ToCharArray())
        {
            textComponentLost.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    
    private IEnumerator TypeLineKilled()
    {
        textComponentKilled.text = string.Empty;

        foreach (char c in linesK[indexKilled].ToCharArray())
        {
            textComponentKilled.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
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
