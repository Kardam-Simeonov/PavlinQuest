using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    public EnemyBehavior behaviorScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Pavlin")
        {
            behaviorScript.isInRoom = true;
            behaviorScript.player = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Pavlin")
        {
            behaviorScript.isInRoom = false;
            behaviorScript.player = collision.gameObject;
        }
    }
}
