using UnityEngine;
using System.Collections;

public class CutsceneMove : CutsceneAction
{
    [Header("Targets")]
    public Transform targetMove;
    public Transform targetDestination;
    public Animator targetAnimator;

    public float speed = 3f;

    public void Awake()
    {
        targetAnimator = targetMove.GetComponent<Animator>();
    }

    public override IEnumerator Execute()
    {
        Vector3 direction = (targetDestination.position - targetMove.position).normalized;

        float moveX = Mathf.Round(direction.x);
        float moveY = Mathf.Round(direction.y);

        targetAnimator.SetFloat("MoveX", moveX);
        targetAnimator.SetFloat("MoveY", moveY);
        targetAnimator.SetBool("isMoving", true);

        while (Vector3.Distance(targetDestination.position, targetMove.position) > 0.01f)
        {
            targetMove.position = Vector3.MoveTowards(targetMove.position, targetDestination.position, speed * Time.deltaTime);

            yield return null;
        }
    }
}
