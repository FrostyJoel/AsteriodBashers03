using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public float maxTimer;
    public float currentTimer;
    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer > GetComponent<ParticleSystem>().main.duration)
        {
            Destroy(gameObject);
        }
    }
}
