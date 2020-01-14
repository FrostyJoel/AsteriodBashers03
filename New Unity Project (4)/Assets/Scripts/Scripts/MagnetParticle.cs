using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetParticle : MonoBehaviour
{
    public ParticleSystem psm;
    public bool MagnetActive;

    public void StopParticle()
    {
        psm.Stop();
    }
    public void PlayParticle()
    {
        if (psm.isPlaying)
        {
            return;
        }

        psm.Play();
    }
}
