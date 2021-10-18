using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthAmount = 10;

    public bool destroyOnPickup = false;

    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.DecreaseHealth(damageAmount);
        }*/

        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(healthAmount);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
