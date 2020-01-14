using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFuel : SpaceJunk
{
    [Header("Particle")]
    public ParticleSystem deathAnimation;
    // Start is called before the first frame update
    void Start()
    {
        SetRotation();
        SetScale();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Laser" || other.tag == "Fuel")
        {
            deathAnimation.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponentInParent<AstroidMovement>().moveSpeed = 0;
            Destroy(parent, deathAnimation.main.duration);
        }
    }
}
