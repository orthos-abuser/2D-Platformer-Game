using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance_of_sound;
    public static SoundManager Instance_of_sound { get { return instance_of_sound; } }

    public SoundType[] Sounds;

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    private void Awake()
    {
        if (instance_of_sound == null)
        {
            instance_of_sound = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Play(global::Sounds.PlayerMove);
    }

    public void footstepsenable()
    {
        soundMusic.Play();
    }

    public void footstepsdisable()
    {
        soundMusic.Stop();
    }

    public void Play(Sounds sound)
    {
        Debug.Log("Here");
        AudioClip clip = getSoundClip(sound);
        if(clip!=null && sound==global::Sounds.ButtonClick)
        {
            soundEffect.PlayOneShot(clip);
        }
        if(clip!=null && sound==global::Sounds.PlayerMove)
        {
            soundMusic.clip = clip;
            soundMusic.loop = true;

        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        else
            return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}


public enum Sounds
{
    ButtonClick,
    PlayerMove,
    Death,
    EnemyDeath,
}
