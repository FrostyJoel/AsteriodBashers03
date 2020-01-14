using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float maxCooldown;
    public float currentCooldown;
    public bool readyToFire;

    public virtual void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            readyToFire = true;
        }
    }
}
