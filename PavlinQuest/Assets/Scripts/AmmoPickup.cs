using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public float ammoValue = 5f;
    public GameObject me;
    public AudioClip[] pickupSounds;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Shoot player = collision.transform.GetComponent<Shoot>();

        if (player != null)
        {
            player.ammoReserve += ammoValue;
            player.GetComponent<AudioSource>().clip = pickupSounds[Random.Range(0, 3)];
            player.GetComponent<AudioSource>().Play();
            Destroy(me);
        }
    }
}
