using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueController : MonoBehaviour
{
    public Text health;
    public Text ammo;
    public Text ammoInMag;

    public Shoot behaviorScript;

    void Update()
    {
        health.text = behaviorScript.health.ToString();
        ammo.text = behaviorScript.ammoReserve.ToString();
        ammoInMag.text = behaviorScript.ammoLoaded.ToString() + " /";
    }
}
