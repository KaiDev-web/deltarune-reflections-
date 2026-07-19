using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ch7_select : MonoBehaviour
{
	public Image ch7_heart;
	public Image ch6_heart;
	public Image ch5_heart;
	public Image ch4_heart;
	public Image ch3_heart;
	public Image ch2_heart;
	public Image ch1_heart;
	
	public void Start()
	{
		ch7_heart.gameObject.SetActive(true);
		ch6_heart.gameObject.SetActive(false);
		ch5_heart.gameObject.SetActive(false);
		ch4_heart.gameObject.SetActive(false);
		ch3_heart.gameObject.SetActive(false);
		ch2_heart.gameObject.SetActive(false);
		ch1_heart.gameObject.SetActive(false);

	}
	
	public void Update()
	{
		if(Keyboard.current.zKey.isPressed && ch7_heart.gameObject.activeSelf)
		{
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
		if(Keyboard.current.upArrowKey.wasPressedThisFrame && ch6_heart.gameObject.activeSelf)
		{
			ch6_heart.gameObject.SetActive(false);
			ch5_heart.gameObject.SetActive(true);
		}
		else if(ch5_heart.gameObject.activeSelf && Keyboard.current.downArrowKey.wasPressedThisFrame)
		{
			ch5_heart.gameObject.SetActive(false);
			ch6_heart.gameObject.SetActive(true);
		}
	}
}