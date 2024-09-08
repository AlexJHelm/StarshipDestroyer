using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        AudioManagerScript.instance.Play("MenuMusic");
        Debug.Log("Playing");
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }

    // Method to set the volume for a specific sound
    public void SetVolume(string soundName, float volume)
    {
        Sound s = Array.Find(sounds, item => item.name == soundName);
        if (s != null)
        {
            s.source.volume = volume;
        }
    }

    // Method to get the volume for a specific sound
    public float GetVolume(string soundName)
    {
        Sound s = Array.Find(sounds, item => item.name == soundName);
        return s != null ? s.source.volume : 0f;
    }
}