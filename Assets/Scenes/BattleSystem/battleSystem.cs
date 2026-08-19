using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class battleSystem : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource selectSound;

    
    [Header("Noelle BBS")]
    public battleSystemNoelle noelle;

    [Header("Check")]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.02f;

    [Header("Item")]
    public TextMeshProUGUI item1;
    public Image item1Hearth;
    public string[] descriptionItem;
    private int indexK;

    private int index;

    [Header("Keyboard")]
    public bool leftArrow = true;
    public bool rightArrow = true;

    [Header("Buttons")]
    public Image fight;
    public Image act;
    public Image item;
    public Image spare;
    public Image defence;
    public Image fightnorm;
    public Image actnorm;
    public Image itemnorm;
    public Image sparenorm;
    public Image defencenorm;
    public Image FightenemyHearth;
    public Image ActenemyHearth;
    public Image SpareenemyHearth;
    public Image DefendeenemyHearth;

    [Header("Texts")]
    public TextMeshProUGUI fightText;
    public TextMeshProUGUI actText;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI spareText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI FightenemyText;
    public TextMeshProUGUI descriptionBattle;
    public TextMeshProUGUI ActenemyText;
    public TextMeshProUGUI CheckenemyText;
    public TextMeshProUGUI SpareenemyText;
    public TextMeshProUGUI DefendeenemyText;
    public float waitSeconds = 1.5f;
    public GameObject krisUnder;
    public GameObject krisUp;
    public GameObject noelleUnder;
    public GameObject noelleUp;

    public void Awake()
    {
        textComponent.text = string.Empty;
    }

    public void Start()
    {
        // KRIS'S TURN!
        Debug.Log("So your checking the code, uh?");
        Debug.Log("Well this stinks.");
        Debug.Log("Kris's Turn.");
        
        noelleUp.gameObject.SetActive(false);
        noelleUnder.gameObject.SetActive(true);
        krisUnder.gameObject.SetActive(false);
        noelle.enabled = false;
        fight.gameObject.SetActive(true);
        act.gameObject.SetActive(false);
        item.gameObject.SetActive(false);
        spare.gameObject.SetActive(false);
        defence.gameObject.SetActive(false);
        FightenemyHearth.gameObject.SetActive(false);
        item1Hearth.gameObject.SetActive(false);
        DefendeenemyHearth.gameObject.SetActive(false);
        

        fightnorm.gameObject.SetActive(false);
        actnorm.gameObject.SetActive(true);
        itemnorm.gameObject.SetActive(true);
        sparenorm.gameObject.SetActive(true);
        defencenorm.gameObject.SetActive(true);

        fightText.gameObject.SetActive(false);
        actText.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
        spareText.gameObject.SetActive(false);
        defenceText.gameObject.SetActive(false);
        FightenemyText.gameObject.SetActive(false);
        ActenemyText.gameObject.SetActive(false);
        CheckenemyText.gameObject.SetActive(false);
        item1.gameObject.SetActive(false);
        DefendeenemyText.gameObject.SetActive(false);

        descriptionBattle.gameObject.SetActive(true);
    }

    void Update()
    {

        if (Keyboard.current.zKey.wasPressedThisFrame && FightenemyHearth.gameObject.activeSelf)
        {
            PlaySound();
            StartCoroutine(WaitToNoelle());
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && fight.gameObject.activeSelf)
        {
            StartCoroutine(Fight());
            FightenemyHearth.gameObject.SetActive(true);
            FightenemyText.gameObject.SetActive(true);
            descriptionBattle.gameObject.SetActive(false);
            leftArrow = false;
            rightArrow = false;
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && fight.gameObject.activeSelf)
        {
            fight.gameObject.SetActive(false);
            defence.gameObject.SetActive(true);
            fightnorm.gameObject.SetActive(true);
            defencenorm.gameObject.SetActive(false);
            StartCoroutine(Defence());
            PlaySound();
        }
        else if(Keyboard.current.leftShiftKey.wasPressedThisFrame && FightenemyHearth.gameObject.activeSelf)
        {
            StopAllCoroutines();
            FightenemyHearth.gameObject.SetActive(false);
            FightenemyText.gameObject.SetActive(false);
            descriptionBattle.gameObject.SetActive(true);
            leftArrow = true;
            rightArrow = true;
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && fight.gameObject.activeSelf)
        {
            fight.gameObject.SetActive(false);
            act.gameObject.SetActive(true);
            fightnorm.gameObject.SetActive(true);
            actnorm.gameObject.SetActive(false);
            StartCoroutine(Act());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && act.gameObject.activeSelf)
        {
           
            if (ActenemyText.gameObject.activeSelf)
            {
                CheckenemyText.gameObject.SetActive(true);
                StartCoroutine(TypeLine());
                ActenemyHearth.gameObject.SetActive(false);
                ActenemyText.gameObject.SetActive(false);
                StartCoroutine(WaitToNoelle());
                PlaySound();
            }
   
            else
            {
                StartCoroutine(Act());
                ActenemyHearth.gameObject.SetActive(true);
                ActenemyText.gameObject.SetActive(true);
                CheckenemyText.gameObject.SetActive(false);
                descriptionBattle.gameObject.SetActive(false);
                leftArrow = false;
                rightArrow = false;
                PlaySound();
            }
        }
        else if(Keyboard.current.zKey.wasPressedThisFrame && CheckenemyText.gameObject.activeSelf)
        {
            StopAllCoroutines();
            CheckenemyText.gameObject.SetActive(false);
            descriptionBattle.gameObject.SetActive(true);
            PlaySound();
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && act.gameObject.activeSelf)
        {
            StopAllCoroutines();
            ActenemyHearth.gameObject.SetActive(false);
            ActenemyText.gameObject.SetActive(false);
            CheckenemyText.gameObject.SetActive(false);
            descriptionBattle.gameObject.SetActive(true);
            leftArrow = true;
            rightArrow = true;
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && CheckenemyText.gameObject.activeSelf)
        {
            CheckenemyText.gameObject.SetActive(false);
            descriptionBattle.gameObject.SetActive(true);
            PlaySound();
        }

        else if(Keyboard.current.leftArrowKey.wasPressedThisFrame && fight.gameObject.activeSelf)
        {
            fight.gameObject.SetActive(false);
            defence.gameObject.SetActive(true);
            fightnorm.gameObject.SetActive(true);
            defencenorm.gameObject.SetActive(false);
            StartCoroutine(Defence());
            PlaySound();
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && DefendeenemyHearth.gameObject.activeSelf)
        {
            PlaySound();
            StartCoroutine(WaitToNoelle());
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && defence.gameObject.activeSelf)
        {
            descriptionBattle.gameObject.SetActive(false);
            DefendeenemyHearth.gameObject.SetActive(true);
            DefendeenemyText.gameObject.SetActive(true);
            PlaySound();
            StartCoroutine(Defence());
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && defence.gameObject.activeSelf)
        {
            descriptionBattle.gameObject.SetActive(true);
            DefendeenemyHearth.gameObject.SetActive(false);
            DefendeenemyText.gameObject.SetActive(false);
            PlaySound();
            StartCoroutine(Defence());
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && defence.gameObject.activeSelf)
        {
            fight.gameObject.SetActive(true);
            defence.gameObject.SetActive(false);
            fightnorm.gameObject.SetActive(false);
            defencenorm.gameObject.SetActive(true);
            StartCoroutine(Fight());
            PlaySound();
        }
        else if(Keyboard.current.rightArrowKey.wasPressedThisFrame && act.gameObject.activeSelf)
        {
            act.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
            actnorm.gameObject.SetActive(true);
            itemnorm.gameObject.SetActive(false);
            StartCoroutine(Item());
            PlaySound();
        }
        else if(Keyboard.current.zKey.wasPressedThisFrame && item.gameObject.activeSelf)
        {
            PlaySound();
            StartCoroutine(Item());
            descriptionBattle.gameObject.SetActive(false);
            item1.gameObject.SetActive(true);
            item1Hearth.gameObject.SetActive(true);

            if (Keyboard.current.zKey.wasPressedThisFrame && item1.gameObject.activeSelf)
            {
                PlaySound();
                StartCoroutine(WaitToNoelle());

            }

        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && item1Hearth.gameObject.activeSelf)
        {
            descriptionBattle.gameObject.SetActive(true);
            item1.gameObject.SetActive(false);
            item1Hearth.gameObject.SetActive(false);
        }
        else if(Keyboard.current.leftArrowKey.wasPressedThisFrame && act.gameObject.activeSelf)
        {
            fight.gameObject.SetActive(true);
            act.gameObject.SetActive(false);
            fightnorm.gameObject.SetActive(false);
            actnorm.gameObject.SetActive(true);
            StartCoroutine(Fight());
            PlaySound();
        }
        else if(Keyboard.current.rightArrowKey.wasPressedThisFrame && item.gameObject.activeSelf)
        {
            item.gameObject.SetActive(false);
            spare.gameObject.SetActive(true);
            itemnorm.gameObject.SetActive(true);
            sparenorm.gameObject.SetActive(false);
            StartCoroutine(Spare());
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && item.gameObject.activeSelf)
        {
            item.gameObject.SetActive(false);
            act.gameObject.SetActive(true);
            itemnorm.gameObject.SetActive(true);
            actnorm.gameObject.SetActive(false);
            StartCoroutine(Act());
            PlaySound();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && spare.gameObject.activeSelf)
        {
            spare.gameObject.SetActive(false);
            defence.gameObject.SetActive(true);
            sparenorm.gameObject.SetActive(true);
            defencenorm.gameObject.SetActive(false);
            StartCoroutine(Defence());
            PlaySound();
        }

        else if (Keyboard.current.zKey.wasPressedThisFrame && SpareenemyHearth.gameObject.activeSelf)
        {
            PlaySound();
            StartCoroutine(WaitToNoelle());
        }
        else if (Keyboard.current.zKey.wasPressedThisFrame && spare.gameObject.activeSelf)
        {
            descriptionBattle.gameObject.SetActive(false);
            SpareenemyHearth.gameObject.SetActive(true);
            SpareenemyText.gameObject.SetActive(true);
            PlaySound();
            StartCoroutine(Spare());
        }
        else if (Keyboard.current.leftShiftKey.wasPressedThisFrame && SpareenemyHearth.gameObject.activeSelf)
        {
            PlaySound();
            descriptionBattle.gameObject.SetActive(true);
            SpareenemyHearth.gameObject.SetActive(false);
            SpareenemyText.gameObject.SetActive(false);
            StartCoroutine(Spare());
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && spare.gameObject.activeSelf)
        {
            spare.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
            sparenorm.gameObject.SetActive(true);
            itemnorm.gameObject.SetActive(false);
            StartCoroutine(Item());
            PlaySound();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && defence.gameObject.activeSelf)
        {
            defence.gameObject.SetActive(false);
            spare.gameObject.SetActive(true);
            defencenorm.gameObject.SetActive(true);
            sparenorm.gameObject.SetActive(false);
            StartCoroutine(Spare());
            PlaySound();
        }
    }


    public void PlaySound()
    {
        selectSound.Play();
    }

    public IEnumerator Fight()
    {
        fightText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        fightText.gameObject.SetActive(false);
    }

    public IEnumerator Act()
    {
        actText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        actText.gameObject.SetActive(false);
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
        itemText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        itemText.gameObject.SetActive(false);
    }

    public IEnumerator Spare()
    {
        spareText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        spareText.gameObject.SetActive(false);
    }

    public IEnumerator Defence()
    {
        defenceText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        defenceText.gameObject.SetActive(false);
    }

    public IEnumerator WaitToNoelle()
    {
        yield return new WaitForSeconds(0.3f);
        noelleUp.gameObject.SetActive(true);
        noelleUnder.gameObject.SetActive(false);

        krisUp.gameObject.SetActive(false);
        krisUnder.gameObject.SetActive(true);
        noelle.enabled = true;
        item1Hearth.gameObject.SetActive(false);
        item1.gameObject.SetActive(false);

        DefendeenemyHearth.gameObject.SetActive(false);
        DefendeenemyText.gameObject.SetActive(false);
        SpareenemyText.gameObject.SetActive(false);
        SpareenemyHearth.gameObject.SetActive(false);
        CheckenemyText.gameObject.SetActive(false);
        FightenemyHearth.gameObject.SetActive(false);
        FightenemyText.gameObject.SetActive(false);
        descriptionBattle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        this.enabled = false;
    }

}

