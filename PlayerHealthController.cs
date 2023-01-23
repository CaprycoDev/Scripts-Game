using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth, currenHealth;

    public float invincibleLength = 1f;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currenHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currenHealth;
        UIController.instance.healthText.text = "HEALTH: " + currenHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0 && !GameManager.instance.levelEnding)
        {
            AudioManager.instance.PlaySFX(7);

            currenHealth -= damageAmount;

            UIController.instance.ShowDamage();

            if (currenHealth <= 0)
            {
                gameObject.SetActive(false);


                currenHealth = 0;

                GameManager.instance.PlayerDied();

                AudioManager.instance.StopBGM();

                AudioManager.instance.PlaySFX(5);
                AudioManager.instance.StopSFX(7);
            }

            invincCounter = invincibleLength;

            UIController.instance.healthSlider.value = currenHealth;
            UIController.instance.healthText.text = "HEALTH: " + currenHealth + "/" + maxHealth;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currenHealth += healAmount;

        if(currenHealth > maxHealth)
        {
            currenHealth = maxHealth;
        }

        UIController.instance.healthSlider.value = currenHealth;
        UIController.instance.healthText.text = "HEALTH: " + currenHealth + "/" + maxHealth;
    }

}
