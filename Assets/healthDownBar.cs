using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class healthDownBar : MonoBehaviour
{
    public Image Bar;
    public TextMeshProUGUI healthText;
    public int maxHealth;
    public int health;
    public int afterDamageHealth;

    private void Start()
    {
        health = maxHealth;
    }


    void Update()
    {
        float fillValue = Mathf.Clamp01((float)health / maxHealth);
        Bar.fillAmount = fillValue;


        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    public void Damage(int damage)
    {
        health -= damage;

        health = Mathf.Clamp(health, 0, maxHealth);
        float fillValue = (float)health / (float)maxHealth;

        if (Bar != null)
        {
            Bar.fillAmount = fillValue;
        }

        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }
    public void Cure(int addHealth)
    {
        health += addHealth;

        health = Mathf.Clamp(health, 0, maxHealth);
        float fillValue = (float)health / (float)maxHealth;

        if (Bar != null)
        {
            Bar.fillAmount = fillValue;
        }

        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    public void Dead()
    {
        if (health < 1 || health == 0)
        {
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadSceneAsync("deathScene");
        }
    }

}