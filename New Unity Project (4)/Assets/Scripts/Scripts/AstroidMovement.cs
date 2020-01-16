using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [Header("Particle")]
    public ParticleSystem deathAnimation;

    [Header("MoveSpeed")]
    public float moveSpeed;
    public float minMovespeed;
    public float maxMovespeed;

    [Header("Damage/Fuel")]
    public float totalAmountOfDamOrFuel;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<JunkStats>() != null)
            {
                int dam = child.GetComponent<JunkStats>().damage;
                totalAmountOfDamOrFuel += dam;
            }
        }
        moveSpeed = Random.Range(minMovespeed, maxMovespeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardRot = transform.rotation * transform.forward;
        transform.Translate(forwardRot *moveSpeed* Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Laser" || other.tag == "Explosion")
        {
            GameManager.instance.soundMan.Play("Explosion " + GameManager.instance.soundMan.RandomExplosionSound().ToString());
            deathAnimation.Play();
            GameManager.instance.uiMan.scoreGot += (GetComponentInChildren<SpaceJunk>().randomScale + GetComponentInChildren<SpaceJunk>().rotSpeed + moveSpeed);
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().enabled = false;
            }
            if (GetComponentInChildren<Renderer>())
            {
                GetComponentInChildren<Renderer>().enabled = false;
            }
            if (GetComponent<Collider>())
            {
                GetComponent<Collider>().enabled = false;
            }
            if (GetComponentInChildren<Collider>())
            {
                GetComponentInChildren<Collider>().enabled = false;
            }
            moveSpeed = 0;
            Destroy(gameObject, deathAnimation.main.duration);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Shield")
    //    {
    //        GameManager.instance.soundMan.Play("ShieldHit");
    //        Destroy(gameObject);
    //    }
    //}
}
