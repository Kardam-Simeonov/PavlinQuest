using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float hpValue = 25f;
    public GameObject me;
    public AudioClip[] drinkSounds;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Shoot player = collision.transform.GetComponent<Shoot>();

        if (player != null)
        {
            if (player.health < 100f)
            {
                player.health += hpValue;
                player.GetComponent<AudioSource>().clip = drinkSounds[Random.Range(0, 2)];
                player.GetComponent<AudioSource>().Play();
                Destroy(me);
            }
        }
    }
}
