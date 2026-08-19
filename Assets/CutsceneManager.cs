using UnityEngine;
using System.Collections;


public class CutsceneManager : MonoBehaviour
{
    public GameObject target;
    public Animator animator;

    [Header("Reference Player")]
    public MonoBehaviour krisMovement;

    public void Awake()
    {
        animator = target.GetComponent<Animator>();

        if(animator != null)
        {
            animator.SetBool("isMoving", false);
            krisMovement.enabled = false;
        }
    }

    private void Start()
    {
        StartCoroutine(RunCoroutine());
    }
    
    private IEnumerator RunCoroutine()
    {
        if(krisMovement != null)
        {
            krisMovement.enabled = false;
        }
        CutsceneAction[] actions = GetComponents<CutsceneAction>();

        foreach (CutsceneAction action in actions)
        {
            yield return StartCoroutine(action.Execute());
        }

        if (krisMovement != null)
        {
            krisMovement.enabled = true;
        }
    }
}