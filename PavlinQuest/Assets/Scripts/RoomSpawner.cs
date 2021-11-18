using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{    
    public int openingDirection;
    // 1 -> need a bottom door
    // 2 -> need a top door
    // 3 -> need a left door
    // 4 -> need a right door

    private RoomTemplates templates;
    private int rand;
    public bool isSpawned = false;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);

        //Accesses the RoomTemplates object, containing the room arrays
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    
    void Spawn()
    {
        if (isSpawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    //Spawn BOTTOM door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;
                case 2:
                    //Spawn TOP door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case 3:
                    //Spawn LEFT door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
                case 4:
                    //Spawn RIGHT door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                default:
                    break;
            }

            isSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().isSpawned == false && isSpawned == false)
            {
                Instantiate(templates.closedRooms[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            isSpawned = true;
        }
    } 
}
