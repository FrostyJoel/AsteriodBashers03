using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : SpaceJunk
{
    [Header("Particle")]
    public ParticleSystem deathAnimation;
    void Start()
    {
        SetScale();
        SetRotation();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Laser" || other.tag == "Explosion")
        {
            deathAnimation.Play();
            GameManager.instance.uiMan.scoreGot += (randomScale + rotSpeed + GetComponentInParent<AstroidMovement>().moveSpeed);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponentInParent<AstroidMovement>().moveSpeed = 0;
            Destroy(parent,deathAnimation.main.duration);
        }
    }
}
