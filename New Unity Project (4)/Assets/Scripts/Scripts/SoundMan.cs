using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundMan : MonoBehaviour
{
    public int maxExplosionSounds;
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        StopAllMusic();
        Play("MenuMusic");
        Play("Ambient");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Not Found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Not Found");
            return;
        }
        s.source.Stop();
    }

    public void StopAllMusic()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void Alarm()
    {
        if (sounds[1].source.isPlaying)
        {
             Play("AlarmSound");
        }
    }
    public int RandomExplosionSound()
    {
        return UnityEngine.Random.Range(0, maxExplosionSounds);
    }
}
