using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject pavlin;

    void Start()
    {
        pavlin = GameObject.Find("Pavlin");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != pavlin && other.gameObject.CompareTag("Projectile") != true && other.gameObject.name != "EnemyVision")
        {
            Destroy(other.gameObject);
        }
    }
}
