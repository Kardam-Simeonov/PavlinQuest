using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Furniture and Props" && collision.gameObject.tag != "TransparentFX")
        {
            Destroy(gameObject);
        }
    }
}
