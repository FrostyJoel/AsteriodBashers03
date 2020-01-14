using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldParticle : MonoBehaviour
{
    public ParticleSystem ps;
    public bool shieldActive;

    public void StopParticle()
    {
        ps.Stop();
    }
    public void PlayParticle()
    {
        if (ps.isPlaying)
        {
            return;
        }

        ps.Play();
    }
}
