using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] _sounds;

    [HideInInspector] public Sound Music;
    [HideInInspector] public Sound Crowd;
    float _musicVolume;
    public float MusicVolume
    {
        get => _musicVolume;
        set
        {
            _musicVolume = value;
            Music._source.volume = value;
        }
    }
    float _sfxVolume;
    public float SFXVolume
    {
        get => _sfxVolume;
        set => _sfxVolume = value;
    }

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;
            s._source.volume = s._volume;
            s._source.pitch = s._pitch;

            if (s.name == "Music")
            {
                Music = s;
                Music._source.loop = true;
                Music._source.volume = MusicVolume;
                Music._source.Play();
            }

            if (s.name == "Crowd")
            {
                Crowd = s;
                Crowd._source.loop = true;
                Crowd._source.Play();
            }

        }
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        s._source.volume = _sfxVolume * s._volume;
        s?._source.Play();

        if (s == null)
        {
            Debug.Log(name + " sound was not found.");
        }
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        s?._source.Stop();

        if (s == null)
        {
            Debug.Log(name + " sound was not found.");
        }
    }

    public void InitializeData()
    {
        _sfxVolume = 0.5f;
        _musicVolume = 0.5f;
    }
}