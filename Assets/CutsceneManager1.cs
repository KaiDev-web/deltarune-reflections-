using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class CutsceneManager1 : MonoBehaviour
{
    [Header("Bools")] 
    public bool c_room1_a = false;
    public bool c_room1_b = false;
    public bool c_room2_a = false;

    [Header("Dialogue")] 
    public GameObject dialogue;

    public GameObject dialogueRoom2;

    [Header("Target's Animator")] 
    public Animator noelleLightWorld;
    public Animator krisLightWorld;
    
    [Header("Target Cutscene")] 
    public Transform c_room1_a_noelle;

    public krisMovement movementKris;
    public BreadcrumbFollower movementNoelle;

    public Transform c_room1_b_kris;

    [Header("Points")] 
    // room 1
    public Transform pointA;

    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    
    // room 2
    public Transform room2_pointA;

    [Header("Movement")] 
    public float moveSpeed = 2f;

    void Start()
    {
        SetMovementEnabled(true);
    }

    public IEnumerator MoveToPoint(Transform target, Transform destination, float speed)
    {
        // Point A to B
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleWalkLeftAnim");
        while (Vector3.Distance(target.position, destination.position) > 0.01f)
        {
            target.position = Vector3.MoveTowards(target.position, destination.position, speed * Time.deltaTime);
            yield return null;
        }

        target.position = destination.position;
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleIdleLeft");
        yield return new WaitForSeconds(0.6f);
        
        // Point B to C
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleWalkUpAnim");
        while (Vector3.Distance(target.position, pointC.position) > 0.01f)
        {
            target.position = Vector3.MoveTowards(target.position, pointC.position, speed * Time.deltaTime);
            yield return null;
        }

        target.position = pointC.position;
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleIdleUp");
        yield return new WaitForSeconds(0.6f);
        
        // Point C to D
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleWalkRightAnim");
        while (Vector3.Distance(target.position, pointD.position) > 0.01f)
        {
            target.position = Vector3.MoveTowards(target.position, pointD.position, speed * Time.deltaTime);
            yield return null;
        }
        
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleIdleRight");
        dialogue.SetActive(true);
        
        target.position = pointD.position;
        yield return new WaitForSeconds(0.6f);

        c_room1_a = false;
        
        if (movementKris != null)
        {
            movementKris.enabled = true;
        }

        if (movementNoelle != null)
        {
            movementNoelle.enabled = true;
        }
    }

    public IEnumerator Room2Move(Transform target, Transform destination, float speed)
    {
        SetMovementEnabled(false);
        
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleIdleLeft");
        if(krisLightWorld != null) krisLightWorld.SetTrigger("krisIdleleft");
        yield return new WaitForSeconds(0.3f);
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleWalkLeftAnim");
        while (Vector3.Distance(target.position, destination.position) > 0.01f)
        {
            target.position = Vector3.MoveTowards(target.position, destination.position, speed * Time.deltaTime);
            yield return null;
        }
        
        dialogue.SetActive(true);

        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleIdleRight");
        dialogueRoom2.SetActive(true);
        
        if(noelleLightWorld != null) noelleLightWorld.SetTrigger("noelleLeftIdle");
        if(krisLightWorld != null) krisLightWorld.ResetControllerState(true); 
        yield return new WaitForSeconds(0.6f);
        SetMovementEnabled(true);
    }
    private void SetMovementEnabled(bool state)
    {
        if (movementKris != null) movementKris.enabled = state;
        if (movementNoelle != null) movementNoelle.enabled = state;
    }
}
