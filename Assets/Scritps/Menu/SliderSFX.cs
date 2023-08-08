using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSFX : MonoBehaviour
{
    const string mixerSFX = "VolumeSFX";
    public Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        AudioManager.instance.audioMixer.SetFloat(mixerSFX, Mathf.Log10(slider.value) * 20);
    }

    public void SetVolume()
    {
        AudioManager.instance.audioMixer.SetFloat(mixerSFX, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", slider.value);
    }
}
