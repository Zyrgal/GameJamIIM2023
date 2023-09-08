using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioClip> soundList;
    public AudioSource audioSource;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < soundList.Count; i++)
        {
            if (soundName == soundList[i].name)
            {
                audioSource.PlayOneShot(soundList[i]);
                return;
            }
        }
    }
}
