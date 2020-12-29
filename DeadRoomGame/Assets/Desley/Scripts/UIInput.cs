using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class UIInput : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject startButton, settingsButton, quitButton;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start")
        {
            Debug.Log("Start was clicked");
            startButton.GetComponent<Button>().onClick.Invoke();
        }
        else if (e.target.name == "Settings")
        {
            Debug.Log("Settings was clicked");
            settingsButton.GetComponent<Button>().onClick.Invoke();
        }
        else if (e.target.name == "Quit")
        {
            Debug.Log("Quit was clicked");
            quitButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Button")
        {
            Debug.Log("Button was exited");
        }
    }
}
