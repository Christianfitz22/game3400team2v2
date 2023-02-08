using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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

    [SerializeField]
    public int ammoMax;
    public int ammoCur;
    private TMP_Text ammoMeter;

    private bool bossWeakened = false;

    [SerializeField]
    private GameObject bossPhase1;
    [SerializeField]
    private GameObject bossPhase2;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthContent = gameObject.transform.Find("PlayerHealthBar").GetComponent<Image>();
        bossHealthContent = gameObject.transform.Find("BossHealthBar").GetComponent<Image>();
        ammoMeter = gameObject.transform.Find("AmmoLabel").GetComponent<TMP_Text>();

        playerHealth = playerMaxHealth;
        bossHealth = bossMaxHealth;
        ammoMeter.SetText("Ammo: " + ammoCur + " / " + ammoMax);

        bossPhase2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            bossWeakened = true;
            bossPhase1.SetActive(false);
            bossPhase2.SetActive(true);
        }
    }

    public void changePlayerHealth(int amount)
    {
        playerHealth += amount;
        playerHealth = Math.Clamp(playerHealth, 0, playerMaxHealth);
        playerHealthContent.fillAmount = (float)playerHealth / (float)playerMaxHealth;
    }

    public void changeBossHealth(int amount)
    {
        if (bossWeakened)
        {
            bossHealth += amount;
            bossHealth = Math.Clamp(bossHealth, 0, bossMaxHealth);
            bossHealthContent.fillAmount = (float)bossHealth / (float)bossMaxHealth;
        }
        else
        {
            Debug.Log("Boss stunned!");
        }
    }

    public void changeAmmo(int amount)
    {
        ammoCur += amount;
        ammoCur = Math.Clamp(ammoCur, 0, ammoMax);
        ammoMeter.SetText("Ammo: " + ammoCur + " / " + ammoMax);
    }

    public void setAmmo(int amount)
    {
        ammoCur = amount;
        ammoCur = Math.Clamp(ammoCur, 0, ammoMax);
        ammoMeter.SetText("Ammo: " + ammoCur + " / " + ammoMax);
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
