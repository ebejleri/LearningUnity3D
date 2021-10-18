using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;

    public PlayerAudio audio;

    private float health;

    public float maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(float amount)
    {
        health += amount;
        Debug.Log("Health Increased, Current Health: " + health);
        UpdateHealthBar();
        if (audio != null)
        {
            audio.PlayHealSound();
        }
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        Debug.Log("Health Decreased, Current Health: " + health);
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player is dead!");
            GameObject.FindObjectOfType<CheckpointManager>().RespawnPlayer();
            health = maxHealth;
        }

        if (audio != null)
        {
            audio.PlayHurtSound();
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float fillAmount = health / maxHealth;
        if (fillAmount > 1)
        {
            fillAmount = 1;
        }

        HealthBar.GetComponent<Image>().fillAmount = fillAmount;
    }

}
