using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Chest : MonoBehaviour
{
    public SteamVR_Action_Boolean input;
    public bool currentInput;
    public float distance;
    public GameObject controler, chest, colorPattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInput = input.state;
        distance = Vector3.Distance(controler.transform.position, chest.transform.position);
        if (currentInput && distance <= 1)
        {
            colorPattern.SetActive(true);
        }
    }
}
