using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicelinePlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PlayVoiceline(int voiceline)
    {
        audioSource.clip = audioClips[voiceline];
        audioSource.Play();
    }

    public void OnWendigoAppear()
    {
        int randomizer = Random.Range(0, 3);
        if(randomizer == 0)
        {
            audioSource.clip = audioClips[10];
            audioSource.Play();
        }
        else if(randomizer == 1)
        {
            audioSource.clip = audioClips[11];
            audioSource.Play();
        }
        else if(randomizer == 2)
        {
            audioSource.clip = audioClips[12];
            audioSource.Play();
        }
    }
}
