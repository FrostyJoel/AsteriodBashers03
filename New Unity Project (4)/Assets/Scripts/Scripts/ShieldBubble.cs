using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBubble : Weapons
{
    public float shieldTimer;
    public GameObject actualShield;
    public ShieldParticle shieldParticle;
    public void Fire()
    {
        StartCoroutine(SetShield());
    }
    IEnumerator SetShield()
    {
        while (readyToFire)
        {
            actualShield.SetActive(true);
            shieldParticle.PlayParticle();
            yield return new WaitForSeconds(shieldTimer);
            shieldParticle.StopParticle();
            actualShield.SetActive(false);
            readyToFire = false;
            currentCooldown = maxCooldown;
        }
    }
}
