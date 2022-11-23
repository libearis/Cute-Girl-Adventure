using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sound)
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
        play("Main Menu");
    }
    public void play(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.Log(name);
            return;
        }
        s.source.Play();
    }

    public void stopSound(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        s.source.Stop();
    }

    public void stopAllSound()
    {
        foreach (Sounds audio in sound)
        {
            audio.source.Stop();
        }
    }

    public void FIndThisScript()
    {
        instance = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }
}
