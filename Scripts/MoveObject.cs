using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject movingObject;
    public GameObject startingPoint;

    public float distance = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //movingObject = gameObject;
        //movingObject = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        float currPositionX = movingObject.transform.position.x;
        if (currPositionX > distance)
        {
           ResetObject(); 
        }
        else
        {
            currPositionX += 0.01f;
            movingObject.transform.position = new Vector3(currPositionX, movingObject.transform.position.y, movingObject.transform.position.z);
        }
    }

    void ResetObject()
    {
        movingObject.transform.position = startingPoint.transform.position;
    }
}
