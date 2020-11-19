using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider master, ambiant, voice;

    void Start()
    {
        master.value = PlayerPrefs.GetFloat("MasterVol");
        ambiant.value = PlayerPrefs.GetFloat("AmbiantVol");
        voice.value = PlayerPrefs.GetFloat("VoiceVol");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MasterVol", master.value);
        PlayerPrefs.SetFloat("AmbiantVol", ambiant.value);
        PlayerPrefs.SetFloat("VoiceVol", voice.value);
        PlayerPrefs.Save();
    }

    public void MasterSetLevel (float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);

    }

    public void AmbiantSetLevel (float sliderValue)
    {
        mixer.SetFloat("AmbiantVol", Mathf.Log10(sliderValue) * 20);
    }

    public void VoiceSetLevel (float sliderValue)
    {
        mixer.SetFloat("VoiceVol", Mathf.Log10(sliderValue) * 20);
    }
}
