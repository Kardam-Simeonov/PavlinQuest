using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSounds : MonoBehaviour
{
    public AudioClip[] stepSounds;
    public MovementScript behaviorScript;

    private double timeStamp;

    void Start()
    {
        timeStamp = Time.time;
    }

    void Update()
    {

        if (behaviorScript.horizontal != 0 || behaviorScript.vertical != 0)
        {
            if (timeStamp <= Time.time)
            {
                GetComponent<AudioSource>().clip = stepSounds[Random.Range(0, 4)];
                GetComponent<AudioSource>().Play();
                timeStamp = Time.time + 0.5;
            }
        }
    }
}
