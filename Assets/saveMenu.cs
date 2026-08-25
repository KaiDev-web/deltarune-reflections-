using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine.InputSystem;

public class saveMenu : MonoBehaviour
{
    [Header("Kris")] 
    public krisMovement movementKr;

    public BoxCollider2D kris;
    public LayerMask savepointLayer;
    public Vector2 lastMoveDirection = Vector2.down;
    
    public GameObject check;
    public bool isStanding;

    public Animator krisAnim;

    [Header("Canva and UI")] 
    public Canvas Save;

    public TextMeshProUGUI NameKris;
    public TextMeshProUGUI LocationText;
    public TextMeshProUGUI SaveButton;
    public TextMeshProUGUI ReturnButton;

    [Header("Sounds")] 
    public AudioSource menuScroll;

    public AudioSource saveSound;

    [Header("Hearts")] 
    public Image saveHearth;

    public Image returnHearth;

    public void Awake()
    {
        kris = GetComponent<BoxCollider2D>();
    }

    public void Start()
    {
        Save.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame &&
            Physics2D.Raycast(transform.position, lastMoveDirection, 1f, savepointLayer))
        {
            movementKr.enabled = false;
            krisAnim.enabled = false;
            Save.gameObject.SetActive(true);
            PlayScroll();
        }
        else
        {
            if (Keyboard.current.rightArrowKey.wasPressedThisFrame && saveHearth.gameObject.activeSelf)
            {
                saveHearth.gameObject.SetActive(false);
                returnHearth.gameObject.SetActive(true);
                SaveButton.color = Color.white;
                ReturnButton.color = Color.yellow;
                PlayScroll();
            }
            else if (Keyboard.current.leftArrowKey.wasPressedThisFrame && returnHearth.gameObject.activeSelf)
            {
                saveHearth.gameObject.SetActive(true);
                returnHearth.gameObject.SetActive(false);
                SaveButton.color = Color.yellow;
                ReturnButton.color = Color.white;
                PlayScroll();
            }
        }
    }

    public void PlayScroll()
    {
        menuScroll.Play();
    }
}
