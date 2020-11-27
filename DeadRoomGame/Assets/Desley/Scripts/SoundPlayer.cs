using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource sound;

    public void InstantiateSound()
    {
        sound.Play();
    }
}
