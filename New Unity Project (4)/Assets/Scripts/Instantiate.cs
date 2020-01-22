using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject instatiate;
    public ParticleSystem ps;
    public int currentRocket;
    public int maxRockets;
    public float maxCooldownTillNewRocket;
    public float currentCooldown;
    public float dis;

    public void FireParticle()
    {
        GameObject g = Instantiate(instatiate, transform.position, transform.rotation);
    }

    public void FireRocket()
    {
        if(currentRocket > 0)
        {
            Instantiate(instatiate, transform.position,Quaternion.Euler(transform.forward));
            currentRocket--;
            GameManager.instance.soundMan.Play("Rocket");
        }
        else
        {
            Debug.Log("No more Rockets");
        }
    }

    private void Update()
    {
        if (currentRocket < maxRockets)
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
            else
            {
                currentCooldown = maxCooldownTillNewRocket;
                currentRocket++;
            }
        }
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position,transform.forward,out hit, dis))
        //{
        //    Debug.DrawRay(transform.position, transform.forward*dis, Color.yellow);
        //}
    }
}
