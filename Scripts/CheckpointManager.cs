using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;

    public Vector3 respawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnLocation = player.transform.position;
    }

    public void RespawnPlayer()
    {
        player.transform.position = respawnLocation;
    }

    public void SetNewCheckpoint(Transform newLocation)
    {
        respawnLocation = newLocation.position;
    }
}
