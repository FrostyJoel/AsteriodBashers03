using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [Header("Particle & Collider & Renderer")]
    public ParticleSystem deathAnimation;
    public Collider propCollider;
    public Renderer propRenderer;

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
            propRenderer.enabled = false;
            propCollider.enabled = false;
            moveSpeed = 0;
            deathAnimation.Play();
            GameManager.instance.soundMan.Play("Explosion " + GameManager.instance.soundMan.RandomExplosionSound().ToString());
            GameManager.instance.uiMan.scoreGot += (GetComponentInChildren<SpaceJunk>().randomScale + GetComponentInChildren<SpaceJunk>().rotSpeed + moveSpeed);
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
