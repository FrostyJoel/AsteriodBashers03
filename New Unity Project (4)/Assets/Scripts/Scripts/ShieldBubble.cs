﻿using System.Collections;
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
        GameManager.instance.soundMan.Play("ShieldActive");
    }
    IEnumerator SetShield()
    {
        while (readyToFire)
        {
            actualShield.SetActive(true);
            shieldParticle.PlayParticle();
            yield return new WaitForSeconds(shieldTimer);
            GameManager.instance.soundMan.Stop("ShieldActive");
            shieldParticle.StopParticle();
            actualShield.SetActive(false);
            readyToFire = false;
            currentCooldown = maxCooldown;
        }
    }
}
