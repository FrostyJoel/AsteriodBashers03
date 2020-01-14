using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("ActualWeapon")]
    public GameObject laserBeam;
    public GameObject shieldBubble;
    public GameObject magnetArm;

    [Header("WeaponSets")]
    public bool laser;
    public bool shield;
    public bool magnet;

    public void ResetWeapons()
    {
        laser = false;
        magnet = false;
        shield = false;
    }
}
