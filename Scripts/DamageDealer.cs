using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10;

    public bool useCollision = true;

    public bool useTrigger = true;

    

    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.DecreaseHealth(damageAmount);
        }*/
        if (useCollision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerHealth health) && !gameObject.CompareTag("Player"))
            {
                health.DecreaseHealth(damageAmount);
            }
            else if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth) && !gameObject.CompareTag("Enemy"))
            {
                enemyHealth.DecreaseHealth(damageAmount);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (useTrigger)
        {
            if (other.gameObject.TryGetComponent(out PlayerHealth health) && !gameObject.CompareTag("Player"))
            {
                health.DecreaseHealth(damageAmount);
            }
            else if (other.gameObject.TryGetComponent(out EnemyHealth enemyHealth) && !gameObject.CompareTag("Enemy"))
            {
                enemyHealth.DecreaseHealth(damageAmount);
            }
        }
    }


}
