using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class deathScene : MonoBehaviour
{
    [Header("Hearts")]
    public Animator startAnim;
    public Image animationCov;
    public Image middle;
    public Image sorry;
    public Image again;

    [Header("Text")]
    public TextMeshProUGUI againText;
    public TextMeshProUGUI sorryText;
    public string NameScene;

    [Header("Cover")]
    public Image coverImage;
    public Image transition;
    public TransitionBack transitionFade;

    void Start()
    {
        againText.gameObject.SetActive(false);
        sorryText.gameObject.SetActive(false);

        again.gameObject.SetActive(false);
        sorry.gameObject.SetActive(false);
        middle.gameObject.SetActive(false);

        coverImage.gameObject.SetActive(false);
        animationCov.gameObject.SetActive(true);
        startAnim.Play("death_0");

        StartCoroutine(AfterAnimation());
    }

    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame && middle.gameObject.activeSelf)
        {
            again.gameObject.SetActive(true);
            sorry.gameObject.SetActive(false);
            middle.gameObject.SetActive(false);


        }

        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && middle.gameObject.activeSelf)
        {
            again.gameObject.SetActive(false);
            sorry.gameObject.SetActive(true);
            middle.gameObject.SetActive(false);

        }

        else if(Keyboard.current.leftArrowKey.wasPressedThisFrame && sorry.gameObject.activeSelf)
        {
            again.gameObject.SetActive(true);
            sorry.gameObject.SetActive(false);
            middle.gameObject.SetActive(false);


        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && again.gameObject.activeSelf)
        {
            again.gameObject.SetActive(false);
            sorry.gameObject.SetActive(true);
            middle.gameObject.SetActive(false);
        }

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            if (again.gameObject.activeSelf)
            {
                StartCoroutine(LoadAgain());
            }
            else if (sorry.gameObject.activeSelf)
            {
                Application.Quit();
            }
        }

    }

    private IEnumerator LoadAgain()
    {
        sorry.gameObject.SetActive(false);
        again.gameObject.SetActive(false);

        sorryText.gameObject.SetActive(false);
        againText.gameObject.SetActive(false);
        coverImage.gameObject.SetActive(false);
       
        
        Debug.Log("Loading ciclo: Fade In");
        float alphaVal = transition.color.a;
        Color tmp = transition.color;

        while (alphaVal < 1f)
        {
            alphaVal += 0.02f;
            tmp.a = alphaVal;

            transition.color = tmp;

            yield return new WaitForSeconds(0.02f);
        }

        tmp.a = alphaVal;
        transition.color = tmp;

        string lastScene = PlayerPrefs.GetString("PreviousScene");
        Debug.LogWarning("Loading lastScene");
        SceneManager.LoadSceneAsync(lastScene);
    }
    public IEnumerator AfterAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        animationCov.gameObject.SetActive(false);
        middle.gameObject.SetActive(true);

        StartCoroutine(FadeInCover());
    }

    private IEnumerator FadeInCover()
    {
        coverImage.gameObject.SetActive(true);
        Debug.Log("Loading ciclo: Fade In");
        float alphaVal = coverImage.color.a;
        Color tmp = coverImage.color;

        while (coverImage.color.a < 1)
        {
            alphaVal += 0.02f;
            tmp.a = alphaVal;

            coverImage.color = tmp;

            yield return new WaitForSeconds(0.02f);
        }

        sorryText.gameObject.SetActive(true);
        againText.gameObject.SetActive(true);

        middle.gameObject.SetActive(true);
    }

}
