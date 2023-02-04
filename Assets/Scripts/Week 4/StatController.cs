using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatController : MonoBehaviour
{
    private int playerHealth;
    [SerializeField]
    private int playerMaxHealth;
    private int bossHealth;
    [SerializeField]
    private int bossMaxHealth;

    private Image playerHealthContent;
    private Image bossHealthContent;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthContent = gameObject.transform.Find("PlayerHealthBar").GetComponent<Image>();
        bossHealthContent = gameObject.transform.Find("BossHealthBar").GetComponent<Image>();

        playerHealth = playerMaxHealth;
        bossHealth = bossMaxHealth;
    }

    public void changePlayerHealth(int amount)
    {
        playerHealth += amount;
        playerHealth = Math.Clamp(playerHealth, 0, playerMaxHealth);
        playerHealthContent.fillAmount = (float)playerHealth / (float)playerMaxHealth;
    }

    public void changeBossHealth(int amount)
    {
        bossHealth += amount;
        playerHealth = Math.Clamp(bossHealth, 0, bossMaxHealth);
        bossHealthContent.fillAmount = (float)bossHealth / (float)bossMaxHealth;
    }

    public bool playerDead()
    {
        return playerHealth <= 0;
    }

    public bool bossDeath()
    {
        return bossHealth <= 0;
    }
}
