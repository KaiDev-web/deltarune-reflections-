using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class attackPatternsEnemies : MonoBehaviour
{
    [Header("GameObjects KrisNoelle")]
    public GameObject krisUnder;
    public GameObject krisUp;
    public GameObject noelleUnder;
    public GameObject noelleUp;

    [Header("DescriptionBattle")] 
    public TextMeshProUGUI descriptionBattle;

    [Header("Discarded Vessel 1")]
    public Transform target;
    public float speedObject = 0f;

    public Transform attack;

    private float minimalDistance = 0.1f;
    private List<Vector3> positionHistory = new List<Vector3>();

    [Header("Discarded Vessel 2")]
    public Transform[] knifes;

    private Vector3 initialPosition;
    [Header("Battle Box")]
    public GameObject battleBox;
    public GameObject soul;
    public soulMovement soulScript;
    public attackPatternsEnemies patternsScript;

    public float attackTime = 6f;

    public Animator bbsAnimator;

    public battleSystemNoelle battleSystem;
    public battleSystem battleSystemKris;


    [Header("Enemies")]
    public GameObject disVessel;
    public GameObject rudinn;

    [Header("Attacks")]
    public bool attackDisVessel1 = false;
    public bool attackDisVessel2 = false;
    public bool attackRudinn1 = false;
    public bool attackRudinn2 = false;

    public void Start()
    {
        descriptionBattle.gameObject.SetActive(false);
        noelleUnder.gameObject.SetActive(true);
        noelleUp.gameObject.SetActive(false);
        battleSystem.enabled = false;
        bbsAnimator.enabled = true;
        ChooseAttack();
    }

    public void ChooseAttack()
    {

        Debug.Log("Entered Void");
        StartTurn();

        if (disVessel != null && disVessel.gameObject.activeSelf)
        {
            int attackChoiceD = Random.Range(1, 3);

            if (attackChoiceD == 1)
            {
                attackDisVessel1 = true;
                Debug.Log("Attack1 Discarded Vessel");
                StartCoroutine(AttackTime());

            }
            else if (attackChoiceD == 2)
            {
                attackDisVessel2 = true;
                Debug.Log("Attack2 Discarded Vessel");
                StartCoroutine(AttackTime());

            }
        }
        else if (rudinn != null && rudinn.gameObject.activeSelf)
        {
            int attackChoiceR = Random.Range(1, 3);

            if (attackChoiceR == 1)
            {
                attackRudinn1 = true;
                Debug.Log("Attack1 Rudinn");
            }
            else if (attackChoiceR == 2)
            {
                attackRudinn2 = true;
                Debug.Log("Attack2 Rudinn");
            }
        }
    }

    public IEnumerator AttackTime()
    {
        float timer = 0f;
        
        if (attackDisVessel2)
        {
            StartCoroutine(AttackDis2());
            if (attack != null) attack.gameObject.SetActive(false);
        }

        while (timer < attackTime)
        {
            if (attackDisVessel1)
            {
                AttackDis1();
            }

            timer += Time.deltaTime;
            yield return null;
        }

        soulScript.enabled = false;
        soul.gameObject.SetActive(false);

        bbsAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        battleBox.SetActive(false);

        attackDisVessel1 = false;
        attackDisVessel2 = false;
        attackRudinn1 = false;
        attackRudinn2 = false;
        battleSystemKris.enabled = true;
        noelleUnder.gameObject.SetActive(true);
        noelleUp.gameObject.SetActive(false);
        krisUp.gameObject.SetActive(true);
        krisUnder.gameObject.SetActive(false);

        EndTurn();
    }

    public void StartTurn()
    {
        battleBox.SetActive(true);

        bbsAnimator.ResetTrigger("Close");
        bbsAnimator.Play("battleBox", 0, 0f);

        soul.SetActive(true);
        soulScript.enabled = true;

        battleSystem.enabled = false;
    }
    
    public IEnumerator AttackDis2()
    {
        yield return new WaitForSeconds(0f);

        foreach (Transform t in knifes)
        {
            if (t != null)
            {
                t.localPosition = new Vector3(-0.21f, 2.25f, 0f);
                t.rotation = Quaternion.identity;

                Rigidbody2D rb = t.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero; 
                    rb.angularVelocity = 0f;
                }

                t.gameObject.SetActive(true);
            }
        }
    }

    public void AttackDis1()
    {
        if (target == null) return;

        RecordTargetPosition();
        MoveAlongHistory();
    }
    

    public void EndTurn()
    {
        attack.gameObject.SetActive(false);
        attack.localPosition = Vector3.zero;
        Debug.Log("Turno finito.");

        attack.gameObject.SetActive(true);
    }

    public void RecordTargetPosition()
    {
        if (positionHistory.Count == 0) 
        {
            positionHistory.Add(target.position);
            return;
        }

        if (positionHistory.Count == 0)
        {
            positionHistory.Add(target.position);
            return;
        }

        Vector3 lastRecordedPosition = positionHistory[positionHistory.Count - 1];
        if (Vector3.Distance(target.position, lastRecordedPosition) >= minimalDistance)
        {
            positionHistory.Add(target.position);
        }

    }
    public void SetupAttack()
    {
        attack.localPosition = new Vector3(4.17f, 0.1885f, 0f);
    }
    
    public void MoveAlongHistory()
    {
        if (positionHistory == null || positionHistory.Count == 0) return;

        Vector3 targetPoint = positionHistory[0];
        
        attack.position = Vector3.MoveTowards(attack.position, targetPoint, speedObject * Time.deltaTime);

        if (Vector3.Distance(attack.position, targetPoint) < 0.05f)
        {
            positionHistory.RemoveAt(0);
        }
    }

}


