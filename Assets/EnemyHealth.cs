using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

public class EnemyhealthBar : MonoBehaviour
{
    [Header("")] 
    public killedEnemy killed;
    
    public TextMeshProUGUI damageText;
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
    }

    public void DamageToEnemy(int damage)
    {
        health -= damage;

        health = Mathf.Clamp(health,0 ,maxHealth);
        float fillValue = (float)health / (float)maxHealth;
        
        StartCoroutine(Text());
    }

    public IEnumerator Text()
    {
        damageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageText.gameObject.SetActive(false);
    }

    public void EnemyDead()
    {
        if (health <= 0)
        {
            int decideFaith = Random.Range(1, 3);

            if (decideFaith == 1)
            {
                killed.LostEnemy();
            }
            else if (decideFaith == 2)
            {
                killed.KilledEnemy();
            }
        }
    }
}