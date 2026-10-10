using System;
using UnityEngine;

public class CutsceneActive : MonoBehaviour
{
    [Header("Cutscene Manager")]
    [SerializeField] CutsceneManager1 cutsceneManager;

    public Transform noelle;
    public Transform destination;
    private float speed = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(cutsceneManager.Room2Move(noelle, destination, speed));
        }
    }
}
