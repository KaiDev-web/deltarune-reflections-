using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class saveMenu : MonoBehaviour
{
    [Header("Kris")] public krisMovement movementKr;

    public LayerMask savepointLayer;
    public Vector2 lastMoveDirection = Vector2.left;

    public Animator krisAnim;

    [Header("Canva and UI")] public Canvas Save;

    public TextMeshProUGUI NameKris;
    public TextMeshProUGUI LocationText;
    public TextMeshProUGUI SaveButton;
    public TextMeshProUGUI ReturnButton;

    [Header("Sounds")] public AudioSource menuScroll;

    public AudioSource saveSound;
    public AudioSource openSave;

    [Header("Hearts")] public Image saveHearth;

    public Image returnHearth;

    public void Update()
    {

        if (!Save.gameObject.activeSelf)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMoveDirection, 1f, savepointLayer);

            if (Keyboard.current.zKey.wasPressedThisFrame && hit.collider != null)
            {
                movementKr.enabled = false;
                krisAnim.enabled = false;
                Save.gameObject.SetActive(true);
                saveHearth.gameObject.SetActive(true);
                returnHearth.gameObject.SetActive(false);
                SaveButton.color = Color.yellow;
                ReturnButton.color = Color.white;
                PlayOpenMenu();
            }
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

            if (Keyboard.current.zKey.wasPressedThisFrame && returnHearth.gameObject.activeSelf)
            {
                movementKr.enabled = true;
                krisAnim.enabled = true;
                Save.gameObject.SetActive(false);
            }
            else if (Keyboard.current.zKey.wasPressedThisFrame && saveHearth.gameObject.activeSelf)
            {
                movementKr.enabled = true;
                krisAnim.enabled = true;
                Save.gameObject.SetActive(false);
                PlaySave();
            }
        }
    }

    public void PlayScroll()
    {
        menuScroll.Play();
    }

    public void PlayOpenMenu()
    {
        openSave.Play();
    }

    public void PlaySave()
    {
        saveSound.Play();
    }
}
