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

    public void FireParticle()
    {
        Instantiate(ps,transform.position,transform.rotation);
    }
    public void FireRocket()
    {
        if(currentRocket > 0)
        {
            Instantiate(instatiate, transform.position,instatiate.transform.rotation);
            currentRocket--;
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
    }
}
