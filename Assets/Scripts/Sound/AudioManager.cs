using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] musics;

    private List<Sound> allSounds = new List<Sound>();

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

            return;
        }

        DontDestroyOnLoad(gameObject);

        SetupSounds();
    }

    private void SetupSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            allSounds.Add(s);
        }

        foreach (Sound m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();

            m.source.clip = m.clip;
            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;

            allSounds.Add(m);
        }
    }

    public void Play(string soundTag)
    {
        Sound s = allSounds.Find(sound => sound.tag == soundTag);

        if (s == null)
        {
            Debug.LogWarning("the sound " + soundTag + " doesnot exist!");

            return;
        }

        s.source.Play();
    }

    public void Pause(string soundTag)
    {
        Sound s = allSounds.Find(sound => sound.tag == soundTag);

        if (s == null)
        {
            Debug.LogWarning("the sound " + soundTag + " doesnot exist!");

            return;
        }

        s.source.Pause();
    }

    public float GetSoundLength(string soundTag)
    {
        Sound s = allSounds.Find(sound => sound.tag == soundTag);

        float length = s.source.clip.length;

        return length;
    }

    public void EnableSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;
        }
    }

    public void DisableSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = 0f;
        }
    }

    public void EnableMusics()
    {
        foreach (Sound m in musics)
        {
            m.source.volume = m.volume;
        }
    }

    public void DisableMusics()
    {
        foreach (Sound m in musics)
        {
            m.source.volume = 0f;
        }
    }
}
