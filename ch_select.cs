using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ch7_select : MonoBehaviour
{
	public Image ch7_heart;
	public Image ch6_heart;
	
	public void Start()
	{
		ch7_heart.gameObject.SetActive(true);
		ch6_heart.gameObject.SetActive(false);
	}
	
	public void Update()
	{
		if(Keyboard.current.zKey.isPressed && ch7_heart.gameObject.activeSelf)
		{
            Debug.Log("Loaded CHAPTER 7");
			SceneManager.LoadScene(1);
		}
		else if(Keyboard.current.upArrowKey.wasPressedThisFrame)
		{
			ch7_heart.gameObject.SetActive(false);
			ch6_heart.gameObject.SetActive(true);
		}
		else if(ch6_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
		{
			ch6_heart.gameObject.SetActive(false);
			ch7_heart.gameObject.SetActive(true);
		}
	}
}