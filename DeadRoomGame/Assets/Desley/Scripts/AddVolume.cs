using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddVolume : MonoBehaviour
{
    public Slider slider;

    public void VolumeUp()
    {
        slider.value += .1f;
    }
    public void VolumeDown()
    {
        slider.value -= .1f;
    }
}
