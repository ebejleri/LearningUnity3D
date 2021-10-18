using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkPointManager;

    public bool destroyOnUse;
    // Start is called before the first frame update
    void Start()
    {
        checkPointManager = GameObject.Find("CheckpointManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointManager.GetComponent<CheckpointManager>().SetNewCheckpoint(gameObject.transform);
            if (destroyOnUse)
            {
                Destroy(gameObject);
            }
        }
    }


}
