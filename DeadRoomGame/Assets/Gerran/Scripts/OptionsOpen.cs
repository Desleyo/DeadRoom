using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OptionsOpen : MonoBehaviour
{

    public SteamVR_Action_Boolean input;
    public bool currentInput;
    public GameObject options, background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInput = input.state;

        if(currentInput == true)
        {
            options.SetActive(true);
            background.SetActive(true);
        }
    }
}
