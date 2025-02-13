﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Weapons
{
    public GameObject magneticField;
    public float magneticTimer;
    public Animator magnetAnimator;
    public MagnetParticle magnetpull;

    public void Fire()
    {
        StartCoroutine(SetMagnet());
    }
    
    public void OpenMagnet()
    {
        magnetAnimator.Play("Folding In");
        GameManager.instance.soundMan.Play("Magnet");
        magnetpull.PlayParticle();
    }

    public void ResetWeapon()
    {
        magnetAnimator.Play("Folding Out");
        GameManager.instance.soundMan.Stop("Magnet");
        magnetpull.StopParticle();
    }

    IEnumerator SetMagnet()
    {
        while (readyToFire)
        {
            OpenMagnet();
            magneticField.SetActive(true);
            yield return new WaitForSeconds(magneticTimer);
            ResetWeapon();
            magneticField.SetActive(false);
            readyToFire = false;
            currentCooldown = maxCooldown;
        }
    }
}
