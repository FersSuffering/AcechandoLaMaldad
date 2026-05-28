using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public Slider healthBar;
    public TextMeshProUGUI healthText, ammoText, pointsText;

    public int points;

    public Image damageEffect;
    public float damageAlpha = 0.7f, damageFadeSpeed = 0.5f;

    public GameObject pauseMenu;
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (damageEffect.color.a != 0)
        {
            damageEffect.color = new Color(
                damageEffect.color.r,
                damageEffect.color.g,
                damageEffect.color.b,
                Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime)
            );
        }
    }

    public void ShowDamage()
    {
        damageEffect.color = new Color(
            damageEffect.color.r,
            damageEffect.color.g,
            damageEffect.color.b,
            0.3f
        );
    }
}
