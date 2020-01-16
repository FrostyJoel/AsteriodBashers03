using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject player;
    private Pointer pointer;
    public bool debugMode;
    public float maxDis;
    float hor, ver;
    public float rotationSpeed;
    public string namePlayer;
    Vector3 v;
    RaycastHit rayHit;


    Ray mouse;
    private void Awake()
    {
        pointer = GetComponent<Pointer>();
    }
    public void DebugMode()
    {
        debugMode = true;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Debug"))
        {
            DebugMode();
        }
        Aiming(pointer.CreateRaycast(pointer.interactableMask));
        if (debugMode)
        {
            mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouse, out rayHit, Mathf.Infinity))
            {
                Interactible(rayHit);
            }
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
            v.y = hor;
            v.x = -ver;
            player.transform.Rotate(v * Time.deltaTime * rotationSpeed);
        }
        else
        {
            return;
        }
    }

    public void Aiming(RaycastHit hit)
    {
        if (hit.collider != null)
        { 
            if (hit.transform.tag == "Asteroid" || hit.transform.tag == "Fuel"||hit.transform.tag == "AimWall" && GameManager.instance.weaponMan.laser)
            {
                GameManager.instance.weaponMan.laserBeam.GetComponent<LaserBeam>().aimPoint = hit.point;
                foreach (GameObject laser in GameManager.instance.weaponMan.laserBeam.GetComponent<LaserBeam>().firePoint)
                {
                    laser.transform.LookAt(hit.point);
                }
            }
            else
            {
                GameManager.instance.weaponMan.laserBeam.GetComponent<LaserBeam>().ResetWeapon();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointer.CreateRaycast(pointer.interactableMask).point, 1);
    }

    public void Interactible(RaycastHit hit)
    {
        rayHit = hit;
        if (!debugMode)
        {
            if (hit.transform.tag == "Button")
            {
                if (!hit.transform.GetComponent<ButtonBase>().triggerd)
                {
                    GameManager.instance.buttonMan.ResetButtonTriggers();
                    CheckButton(hit);
                }
                else
                {
                    GameManager.instance.buttonMan.ResetButtonTriggers();
                    GameManager.instance.weaponMan.ResetWeapons();
                }
            }
            CheckWeapon();
            if (hit.transform.tag == "UIButton")
            {
                hit.transform.GetComponent<UIButtonBase>().triggerd = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //SetScore();
                if (hit.transform.tag == "Button")
                {
                    if (!hit.transform.GetComponent<ButtonBase>().triggerd)
                    {
                        GameManager.instance.buttonMan.ResetButtonTriggers();
                        CheckButton(hit);
                    }
                    else
                    {
                        GameManager.instance.buttonMan.ResetButtonTriggers();
                        GameManager.instance.weaponMan.ResetWeapons();
                    }
                }
                CheckWeapon();
                if (hit.transform.tag == "UIButton")
                {
                    hit.transform.GetComponent<UIButtonBase>().triggerd = true;
                }
            }
        }
    }

    public void CheckWeapon()
    {
        if (rayHit.transform.tag != "Button" && rayHit.transform.tag != "Ship" && rayHit.transform.tag != "RocketButton")
        {
            if (GameManager.instance.weaponMan.laser)
            {
                GameManager.instance.weaponMan.laserBeam.GetComponent<LaserBeam>().Fire();
            }
            if (GameManager.instance.weaponMan.shield)
            {
                GameManager.instance.weaponMan.shieldBubble.GetComponent<ShieldBubble>().Fire();
            }
            if (GameManager.instance.weaponMan.magnet)
            {
                GameManager.instance.weaponMan.magnetArm.GetComponent<Magnet>().Fire();
                GameManager.instance.weaponMan.magnetArm.GetComponent<Magnet>().OpenMagnet();
            }
        }
        if(rayHit.transform.tag == "RocketButton")
        {
            GameManager.instance.weaponMan.GetComponent<Instantiate>().FireRocket();
        }
    }

    public void CheckButton(RaycastHit hit)
    {
        if (hit.transform.GetComponent<LaserButton>() != null)
        {
            hit.transform.GetComponent<LaserButton>().triggerd = true;
            hit.transform.GetComponent<LaserButton>().Selected();
        }
        if (hit.transform.GetComponent<ShieldButton>() != null)
        {
            hit.transform.GetComponent<ShieldButton>().triggerd = true;
            hit.transform.GetComponent<ShieldButton>().Selected();
        }
        if (hit.transform.GetComponent<MagnetButton>() != null)
        {
            hit.transform.GetComponent<MagnetButton>().triggerd = true;
            hit.transform.GetComponent<MagnetButton>().Selected();
        }
    }
}
