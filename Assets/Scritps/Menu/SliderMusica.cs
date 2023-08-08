using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusica : MonoBehaviour
{
    const string mixerMusic = "VolumeMusica";
    public Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        AudioManager.instance.audioMixer.SetFloat(mixerMusic, Mathf.Log10(slider.value) * 20);
    }
    public void SetVolume()
    {
        AudioManager.instance.audioMixer.SetFloat(mixerMusic, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }
}
