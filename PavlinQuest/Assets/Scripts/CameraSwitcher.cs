using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Player goes Left
        if (transform.position.x - player.position.x >= 10)
            transform.position = new Vector3(transform.position.x - 18, transform.position.y, offset.z);

        //Player goes Right
        else if (transform.position.x - player.position.x <= -10)
            transform.position = new Vector3(transform.position.x + 18, transform.position.y, offset.z);

        //Player goes Down
        else if (transform.position.y - player.position.y >= 7)
            transform.position = new Vector3(transform.position.x, transform.position.y - 14, offset.z);

        //Player goes Up
        else if (transform.position.y - player.position.y <= -7)
                    transform.position = new Vector3(transform.position.x, transform.position.y + 14, offset.z);
       
    }
}
