using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;

    public bool chase = false;

    public float movementSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && chase)
        {
            Chase();
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            chase = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            chase = false;
        }
    }

    public void Chase()
    {
        transform.LookAt(player.transform.position);
        transform.position = (transform.forward * movementSpeed) + transform.position;
    }

}
