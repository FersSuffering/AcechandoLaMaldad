using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int maxHealth, currentHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        UI.instance.healthBar.maxValue = maxHealth;
    }

    void Update()
    {
        UI.instance.healthBar.value = currentHealth;
        UI.instance.healthText.text = "" + currentHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;

        UI.instance.ShowDamage();

        if (currentHealth <= 0) 
        {
            GameManager.instance.Lose();
        }
    }

    public void HealPlayer(int heal) 
    {
        currentHealth += heal;

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
