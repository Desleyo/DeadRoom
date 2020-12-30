using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class UIInput : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Color normalColor, hoverColor;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Button")
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Button")
        {
            e.target.GetComponent<Image>().color = hoverColor;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "Button")
        {
            e.target.GetComponent<Image>().color = normalColor;
        }
    }
}
