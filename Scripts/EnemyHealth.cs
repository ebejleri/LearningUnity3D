using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public float maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(float amount)
    {
        health += amount;
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
