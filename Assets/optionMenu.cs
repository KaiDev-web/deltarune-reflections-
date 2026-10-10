using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator optionsMenu;
    [SerializeField] private Animator statsMenu;

    [Header("Sound")] 
    [SerializeField] private AudioSource select;
    [SerializeField] private AudioSource move;

    [Header("Movements")] 
    public krisMovement kris;
    public BreadcrumbFollower thaTroupe; // la troupe yeah

    [Header("Buttons")] 
    // ----- NO SELECTED -----
    [SerializeField] private Image itemNo;
    [SerializeField] private Image equipNo;
    [SerializeField] private Image magicNo;
    [SerializeField] private Image configNo;
    
    // ----- SELECTED -----
    [SerializeField] private Image item;
    [SerializeField] private Image equip;
    [SerializeField] private Image magic;
    [SerializeField] private Image config;

    [Header("Settings")]
    [SerializeField] private Key toggleKey = Key.C;

    private bool menuOpen;

    private static readonly int OpenMenuHash = Animator.StringToHash("openMenu");
    private static readonly int CloseMenuHash = Animator.StringToHash("closeMenu");
    private static readonly int OpenStatsHash = Animator.StringToHash("openStats");
    private static readonly int CloseStatsHash = Animator.StringToHash("closeStats");

    private void Awake()
    {
        if (optionsMenu == null && statsMenu == null)
        {
            optionsMenu = GetComponent<Animator>();
            statsMenu = GetComponent<Animator>();
        }

        if (optionsMenu == null && statsMenu == null)
        {
            Debug.LogError(
                "[OptionMenu] Nessun Animator assegnato o trovato.",
                this
            );
        }
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        KeyControl key = Keyboard.current[toggleKey];

        if (key != null && key.wasPressedThisFrame)
        {
            ToggleMenu();
        }
        
        if (menuOpen)
        {
            SelectMenuOptions();
        }
    }

    private void ToggleMenu()
    {
        if (optionsMenu == null && statsMenu == null)
            return;

        if (menuOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        menuOpen = true;
        kris.enabled = false;
        thaTroupe.enabled = false;

        optionsMenu.ResetTrigger("closeMenu");
        statsMenu.ResetTrigger("closeStats");
        optionsMenu.SetTrigger("openMenu");
        statsMenu.SetTrigger("openStats");
        
        // Item Selected
        
        item.gameObject.SetActive(true);
        equipNo.gameObject.SetActive(true);
        magicNo.gameObject.SetActive(true);
        configNo.gameObject.SetActive(true);
        PlayMove();
    }

    private void CloseMenu()
    {
        menuOpen = false;
        kris.enabled = true;
        thaTroupe.enabled = true;
        
        optionsMenu.ResetTrigger("openMenu");
        statsMenu.ResetTrigger("openStats");
        optionsMenu.SetTrigger("closeMenu");
        statsMenu.SetTrigger("closeStats");
    }

    public void SelectMenuOptions()
    {
        
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame && item.gameObject.activeSelf)
        {
            // Equip Selected
            itemNo.gameObject.SetActive(true);
            item.gameObject.SetActive(false);
            equipNo.gameObject.SetActive(false);
            equip.gameObject.SetActive(true);
            PlayMove();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && equip.gameObject.activeSelf)
        {
            // Magic Selected
            
            equip.gameObject.SetActive(false);
            equipNo.gameObject.SetActive(true);
            magicNo.gameObject.SetActive(false);
            magic.gameObject.SetActive(true);
            PlayMove();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && magic.gameObject.activeSelf)
        {
            // Config Selected

            magicNo.gameObject.SetActive(true);
            magic.gameObject.SetActive(false);
            config.gameObject.SetActive(true);
            configNo.gameObject.SetActive(false);
            PlayMove();
        }
        
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && config.gameObject.activeSelf)
        {
            // Item Selected Again
            
            config.gameObject.SetActive(false);
            configNo.gameObject.SetActive(true);
            itemNo.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
            PlayMove();
        }
    }

    public void PlayMove()
    {
        move.Play();
    }

    public void PlaySelect()
    {
        select.Play();
    }

    public void ForceOpen()
    {
        OpenMenu();
    }

    public void ForceClose()
    {
        CloseMenu();
    }

    public bool IsMenuOpen()
    {
        return menuOpen;
    }
}
