using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : Weapons
{
    public List<GameObject> laserCannons = new List<GameObject>();
    public List<GameObject> firePoint = new List<GameObject>();
    public Vector3 aimPoint;
    public float turnSpeed;
    bool reset;

    [Header("Strings UX")]
    public string LaserReady = "Laser Gereed";
    public string LaserRecharging = "Laser opladen";

    public void Fire()
    {
        if (readyToFire)
        {
            GameManager.instance.soundMan.Play("LaserBeam");
            foreach (GameObject laser in laserCannons)
            {
                laser.GetComponentInChildren<Instantiate>().FireParticle();
            }
            readyToFire = false;
            currentCooldown = maxCooldown;

        }
    }
    public void ResetWeapon()
    {
        reset = true;
    }
    public override void Update()
    {
        base.Update();
        if (reset)
        {
            foreach (GameObject laser in laserCannons)
            {
                //laser.transform.localPosition = laser.GetComponent<WeaponRot>().startingPos;
                //laser.transform.localEulerAngles = laser.GetComponent<WeaponRot>().startingRot;
            }
            
        }
    }
}
