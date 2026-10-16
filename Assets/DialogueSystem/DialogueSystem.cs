using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.05f;
    public MonoBehaviour movement;

    public Image[] images; // opzionale: un'immagine per ogni riga

    [SerializeField] private OptionMenu options;

    private int index;

    void OnEnable()
    {
        movement.enabled = false;
        options.enabled = false;
    }

    void Start()
    {
        StartDialogue();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        ShowImage();
        StartLine();
    }

    void StartLine()
    {
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            ShowImage();
            StartLine();
        }
        else
        {
            movement.enabled = true;
            options.enabled = true;
            gameObject.SetActive(false);
        }
    }

    void ShowImage()
    {
        if (images == null) return;

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i] != null)
                images[i].gameObject.SetActive(i == index);
        }
    }
}