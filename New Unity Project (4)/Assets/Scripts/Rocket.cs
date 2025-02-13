﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float currentTime;
    public float explosionTime;
    public ParticleSystem explosion;
   
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= explosionTime)
        {

            Explode();
        }
    }
    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        AstroidMovement[] allStuff = FindObjectsOfType<AstroidMovement>();
        foreach (AstroidMovement astroidMovement  in allStuff)
        {
            GameManager.instance.soundMan.Play("Explosion " + GameManager.instance.soundMan.RandomExplosionSound().ToString());
            Destroy(astroidMovement.gameObject);
        }

        Destroy(gameObject);
    }
}
