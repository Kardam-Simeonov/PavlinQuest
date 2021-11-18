using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] closedRooms;

    public List<GameObject> spawnedRooms;

    public float waitTime;
    private bool spawnedExit;
    public GameObject exit;

    private void Update()
    {
        if (waitTime <= 0 && spawnedExit == false)
        {
            //RoomSpawner lastRoomScript = spawnedRooms[spawnedRooms.Count - 1].GetComponentInChildren<RoomSpawner>();


            Instantiate(exit, spawnedRooms[spawnedRooms.Count - 1].transform.position, Quaternion.identity);
            Destroy(spawnedRooms[spawnedRooms.Count - 1]);

            spawnedExit = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
