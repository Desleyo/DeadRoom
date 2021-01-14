using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;

public class OptionsOpen : MonoBehaviour
{

    public SteamVR_Action_Boolean input;
    public bool currentInput, opened;
    public GameObject options, background, rightHand;
    float timer;

    void Start()
    {
        rightHand = GetComponentInParent<Hand>().otherHand.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        currentInput = input.state;

        if(currentInput && !opened && timer <= 0)
        {
            options.SetActive(true);
            background.SetActive(true);
            rightHand.GetComponent<SteamVR_LaserPointer>().enabled = true;
            opened = true;
            timer = .3f;
        }
        else if(currentInput && opened && timer <= 0)
        {
            options.SetActive(false);
            background.SetActive(false);
            rightHand.GetComponent<SteamVR_LaserPointer>().enabled = false;
            opened = false;
            timer = .3f;
        }

        timer -= Time.deltaTime;
    }
}
