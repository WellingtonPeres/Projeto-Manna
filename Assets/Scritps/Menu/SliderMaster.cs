using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMaster : MonoBehaviour
{
    const string mixerMaster = "VolumeMaster";
    public Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        AudioManager.instance.audioMixer.SetFloat(mixerMaster, Mathf.Log10(slider.value) * 20);
    }

    public void SetVolume()
    {
        AudioManager.instance.audioMixer.SetFloat(mixerMaster, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", slider.value);
    }
}
