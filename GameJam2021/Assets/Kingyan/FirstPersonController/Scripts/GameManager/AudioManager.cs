//Author: Kingyan Incorporated

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spacialBlend;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
            s.source.playOnAwake = false;

            if (s.randomPitch)
            {
                s.source.pitch = s.pitch * UnityEngine.Random.Range(0.8f, 1.1f);
            } 
            else
            {
                s.source.pitch = s.pitch;
            }
        }
    }

    /// <summary>
    /// Plays a sound with the appropriate name
    /// </summary>
    public void PlaySound(string name)
    {
        if (isExisting(name))
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }

    /// <summary>
    /// Stops a sound with the appropriate name
    /// </summary>
    public void StopSound(string name)
    {
        if (isExisting(name))
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
        }
    }

    /// <summary>
    /// Returns whether or not a sound is playing
    /// </summary>
    public bool IsPlaying(string name)
    {
        if (isExisting(name))
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            return s.source.isPlaying;
        } else
        {
            return false;
        }
    }

    public bool isExisting(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
        {
            return true;
        } else
        {
            Debug.LogWarning("Unable to find and play " + name + "sound");
            return false;
        }
    }
}

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    public AudioMixerGroup audioMixerGroup;
    public bool randomPitch;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [Range(0f, 1f)]
    public float spacialBlend;

    [HideInInspector]
    public AudioSource source;
}
