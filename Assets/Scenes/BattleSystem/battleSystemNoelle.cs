using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class battleSystemNoelle : MonoBehaviour
{
    [Header("EnemyHealth")] 
    public EnemyhealthBar enemy;
    
    [Header("Sound")]
    public AudioSource selectSound;

    [Header("Pattern Reciever")]
    public attackPatternsEnemies attackPatternsEnemies;

    [Header("HealthBars")]
    public healthBar health1;
    public healthDownBar health2;

    [Header("Item")]
    public TextMeshProUGUI item1N;
    public Image item1HearthN;
    public TextMeshProUGUI descriptionItem1;
    public TextMeshProUGUI descriptionItem12;
    public TextMeshProUGUI textComponentN;
    
    [Header("Check")]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.02f;

    private int index;

    [Header("Keyboard")]
    public bool leftArrow = true;
    public bool rightArrow = true;

    [Header("Buttons")]
    public Image fightN;
    public Image actN;
    public Image itemN;
    public Image spareN;
    public Image defenceN;
    public Image fightnormN;
    public Image actnormN;
    public Image itemnormN;
    public Image sparenormN;
    public Image defencenormN;
    public Image FightenemyHearthN;
    public Image ActenemyHearthN;
    public Image SpareenemyHearthN;
    public Image DefendeenemyHearthN;

    [Header("Texts")]
    public TextMeshProUGUI fightTextN;
    public TextMeshProUGUI actTextN;
    public TextMeshProUGUI itemTextN;
    public TextMeshProUGUI spareTextN;
    public TextMeshProUGUI defenceTextN;
    public TextMeshProUGUI FightenemyTextN;
    public TextMeshProUGUI descriptionBattleN;
    public TextMeshProUGUI ActenemyTextN;
    public TextMeshProUGUI CheckenemyTextN;
    public TextMeshProUGUI SpareenemyTextN;
    public TextMeshProUGUI DefendeenemyTextN;
    public float waitSeconds = 1.5f;
    public GameObject noelleUnder;
    public GameObject noelleUp;

    public void Awake()
    {
        textComponent.text = string.Empty;
    }

    public void Start()
    {
        // NOELLE'S TURN!
        Debug.Log("Noelle's Turn");
        
        textComponentN.gameObject.SetActive(true);
        noelleUp.gameObject.SetActive(true);
        noelleUnder.gameObject.SetActive(false);
        attackPatternsEnemies.enabled = false;

        fightN.gameObject.SetActive(true);
        actN.gameObject.SetActive(false);
        itemN.gameObject.SetActive(false);
        spareN.gameObject.SetActive(false);
        defenceN.gameObject.SetActive(false);
        FightenemyHearthN.gameObject.SetActive(false);
        item1HearthN.gameObject.SetActive(false);

        fightnormN.gameObject.SetActive(false);
        actnormN.gameObject.SetActive(true);
        itemnormN.gameObject.SetActive(true);
        sparenormN.gameObject.SetActive(true);
        defencenormN.gameObject.SetActive(true);
        descriptionItem1.gameObject.SetActive(false);
        descriptionItem12.gameObject.SetActive(false);

        fightTextN.gameObject.SetActive(false);
        actTextN.gameObject.SetActive(false);
        itemTextN.gameObject.SetActive(false);
        spareTextN.gameObject.SetActive(false);
        defenceTextN.gameObject.SetActive(false);
        FightenemyTextN.gameObject.SetActive(false);
        ActenemyTextN.gameObject.SetActive(false);
        CheckenemyTextN.gameObject.SetActive(false);
        item1N.gameObject.SetActive(false);

        descriptionBattleN.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame && FightenemyHearthN.gameObject.activeSelf)
        {
            PlaySound();
            enemy.DamageToEnemy(10);
            FightenemyTextN.gameObject.SetActive(false);
            FightenemyHearthN.gameObject.SetActive(false);
            PassToEnemyTurn();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && fightN.gameObject.activeSelf)
        {
            StartCoroutine(Fight());
            FightenemyHearthN.gameObject.SetActive(true);
            FightenemyTextN.gameObject.SetActive(true);
            descriptionBattleN.gameObject.SetActive(false);
            leftArrow = false;
            rightArrow = false;
            PlaySound();
        }
        
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && FightenemyHearthN.gameObject.activeSelf)
        {
            StopAllCoroutines();
            FightenemyHearthN.gameObject.SetActive(false);
            FightenemyTextN.gameObject.SetActive(false);
            descriptionBattleN.gameObject.SetActive(true);
            leftArrow = true;
            rightArrow = true;
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && fightN.gameObject.activeSelf)
        {
            fightN.gameObject.SetActive(false);
            actN.gameObject.SetActive(true);
            fightnormN.gameObject.SetActive(true);
            actnormN.gameObject.SetActive(false);
            StartCoroutine(Act());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && actN.gameObject.activeSelf)
        {

            if (ActenemyTextN.gameObject.activeSelf)
            {
                CheckenemyTextN.gameObject.SetActive(true);
                StartCoroutine(TypeLine());
                ActenemyHearthN.gameObject.SetActive(false);
                ActenemyTextN.gameObject.SetActive(false);
                noelleUnder.gameObject.SetActive(true);
                noelleUp.gameObject.SetActive(false);
                PassToEnemyTurn();
                PlaySound();
            }

            else
            {
                StartCoroutine(Act());
                ActenemyHearthN.gameObject.SetActive(true);
                ActenemyTextN.gameObject.SetActive(true);
                CheckenemyTextN.gameObject.SetActive(false);
                descriptionBattleN.gameObject.SetActive(false);
                leftArrow = false;
                rightArrow = false;
                PlaySound();
            }
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && CheckenemyTextN.gameObject.activeSelf)
        {
            StopAllCoroutines();
            CheckenemyTextN.gameObject.SetActive(false);
            descriptionBattleN.gameObject.SetActive(true);
            PlaySound();
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && actN.gameObject.activeSelf)
        {
            StopAllCoroutines();
            ActenemyHearthN.gameObject.SetActive(false);
            ActenemyTextN.gameObject.SetActive(false);
            CheckenemyTextN.gameObject.SetActive(false);
            descriptionBattleN.gameObject.SetActive(true);
            leftArrow = true;
            rightArrow = true;
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && CheckenemyTextN.gameObject.activeSelf)
        {
            CheckenemyTextN.gameObject.SetActive(false);
            descriptionBattleN.gameObject.SetActive(true);
            PlaySound();
        }

        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && fightN.gameObject.activeSelf)
        {
            fightN.gameObject.SetActive(false);
            defenceN.gameObject.SetActive(true);
            fightnormN.gameObject.SetActive(true);
            defencenormN.gameObject.SetActive(false);
            StartCoroutine(Defence());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && DefendeenemyHearthN.gameObject.activeSelf)
        {
            PlaySound();
            DefendeenemyHearthN.gameObject.SetActive(false);
            DefendeenemyTextN.gameObject.SetActive(false);
            PassToEnemyTurn();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && defenceN.gameObject.activeSelf)
        {
            descriptionBattleN.gameObject.SetActive(false);
            DefendeenemyHearthN.gameObject.SetActive(true);
            DefendeenemyTextN.gameObject.SetActive(true);
            PlaySound();
            StartCoroutine(Defence());
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && defenceN.gameObject.activeSelf)
        {
            descriptionBattleN.gameObject.SetActive(true);
            DefendeenemyHearthN.gameObject.SetActive(false);
            DefendeenemyTextN.gameObject.SetActive(false);
            PlaySound();
            StartCoroutine(Defence());
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && defenceN.gameObject.activeSelf)
        {
            fightN.gameObject.SetActive(true);
            defenceN.gameObject.SetActive(false);
            fightnormN.gameObject.SetActive(false);
            defencenormN.gameObject.SetActive(true);
            StartCoroutine(Fight());
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && actN.gameObject.activeSelf)
        {
            actN.gameObject.SetActive(false);
            itemN.gameObject.SetActive(true);
            actnormN.gameObject.SetActive(true);
            itemnormN.gameObject.SetActive(false);
            StartCoroutine(Item());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && item1N.gameObject.activeSelf)
        {
            PlaySound();
            item1HearthN.gameObject.SetActive(false);
            item1N.gameObject.SetActive(false);
            textComponentN.gameObject.SetActive(true);
            StartCoroutine(DescriptionItem());
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && itemN.gameObject.activeSelf)
        {
            PlaySound();
            StartCoroutine(Item());
            descriptionBattleN.gameObject.SetActive(false);
            item1N.gameObject.SetActive(true);
            item1HearthN.gameObject.SetActive(true);
        }

        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && item1HearthN.gameObject.activeSelf)
        {
            descriptionBattleN.gameObject.SetActive(true);
            item1N.gameObject.SetActive(false);
            item1HearthN.gameObject.SetActive(false);
        }

        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && actN.gameObject.activeSelf)
        {
            fightN.gameObject.SetActive(true);
            actN.gameObject.SetActive(false);
            fightnormN.gameObject.SetActive(false);
            actnormN.gameObject.SetActive(true);
            StartCoroutine(Fight());
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && itemN.gameObject.activeSelf)
        {
            itemN.gameObject.SetActive(false);
            spareN.gameObject.SetActive(true);
            itemnormN.gameObject.SetActive(true);
            sparenormN.gameObject.SetActive(false);
            StartCoroutine(Spare());
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && itemN.gameObject.activeSelf)
        {
            itemN.gameObject.SetActive(false);
            actN.gameObject.SetActive(true);
            itemnormN.gameObject.SetActive(true);
            actnormN.gameObject.SetActive(false);
            StartCoroutine(Act());
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && spareN.gameObject.activeSelf)
        {
            spareN.gameObject.SetActive(false);
            defenceN.gameObject.SetActive(true);
            sparenormN.gameObject.SetActive(true);
            defencenormN.gameObject.SetActive(false);
            StartCoroutine(Defence());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && SpareenemyHearthN.gameObject.activeSelf)
        {
            PlaySound();
            noelleUnder.gameObject.SetActive(true);
            noelleUp.gameObject.SetActive(false);
            SpareenemyHearthN.gameObject.SetActive(false);
            SpareenemyTextN.gameObject.SetActive(false);
            PassToEnemyTurn();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && spareN.gameObject.activeSelf)
        {
            descriptionBattleN.gameObject.SetActive(false);
            SpareenemyHearthN.gameObject.SetActive(true);
            SpareenemyTextN.gameObject.SetActive(true);
            PlaySound();
            StartCoroutine(Spare());
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && SpareenemyHearthN.gameObject.activeSelf)
        {
            PlaySound();
            descriptionBattleN.gameObject.SetActive(true);
            SpareenemyHearthN.gameObject.SetActive(false);
            SpareenemyTextN.gameObject.SetActive(false);
            StartCoroutine(Spare());
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && spareN.gameObject.activeSelf)
        {
            spareN.gameObject.SetActive(false);
            itemN.gameObject.SetActive(true);
            sparenormN.gameObject.SetActive(true);
            itemnormN.gameObject.SetActive(false);
            StartCoroutine(Item());
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && defenceN.gameObject.activeSelf)
        {
            defenceN.gameObject.SetActive(false);
            spareN.gameObject.SetActive(true);
            defencenormN.gameObject.SetActive(true);
            sparenormN.gameObject.SetActive(false);
            StartCoroutine(Spare());
            PlaySound();
        }
    }

    public void PassToEnemyTurn()
    {
        leftArrow = false;
        rightArrow = false;

        if (attackPatternsEnemies != null)
        {
            attackPatternsEnemies.enabled = true;
            attackPatternsEnemies.ChooseAttack();
        }
    }
    public void CureAll(int cure)
    {
        if (health1 != null) health1.Cure(cure);
        if (health2 != null) health2.Cure(cure);
    }

    public void PlaySound()
    {
        selectSound.Play();
    }

    public IEnumerator Fight()
    {
        fightTextN.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        fightTextN.gameObject.SetActive(false);
    }

    public IEnumerator DescriptionItem()
    {
        if(descriptionItem1 != null && descriptionItem12 != null)
        {
            Debug.Log("Selected Item 1.");
        }
        yield return new WaitForSeconds(0.02f);
        descriptionItem1.gameObject.SetActive(true);

        while (!Keyboard.current.zKey.wasPressedThisFrame) yield return null;
        item1HearthN.gameObject.SetActive(false);
        item1N.gameObject.SetActive(false);

        descriptionItem1.gameObject.SetActive(false);
        descriptionItem12.gameObject.SetActive(true);

        yield return null;

        while (!Keyboard.current.zKey.wasPressedThisFrame) yield return null;
        item1HearthN.gameObject.SetActive(false);
        item1N.gameObject.SetActive(false);

        descriptionItem12.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        attackPatternsEnemies.enabled = true;
        CureAll(1);
        

    }
    public IEnumerator Act()
    {
        actTextN.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        actTextN.gameObject.SetActive(false);
    }

    public IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    public IEnumerator Item()
    {
        itemTextN.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        itemTextN.gameObject.SetActive(false);
    }

    public IEnumerator Spare()
    {
        spareTextN.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        spareTextN.gameObject.SetActive(false);
    }

    public IEnumerator Defence()
    {
        defenceTextN.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        defenceTextN.gameObject.SetActive(false);
    }

    public void CallDead()
    {
        if (health1.health < 1 && health2.health < 1)
        {
            health1.Dead();
        }
    }
}


