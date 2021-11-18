using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Furniture and Props")
        {
            Destroy(gameObject);
        }
    }
}
