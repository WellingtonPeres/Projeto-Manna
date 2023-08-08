using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static AudioManager instance;

    public AudioSource SFXSource;
    public AudioSource MusicSource;
    public AudioClip click;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayConfirmSFX()
    {
        SFXSource.PlayOneShot(click);
    }
}
