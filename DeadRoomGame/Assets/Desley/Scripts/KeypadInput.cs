using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInput : MonoBehaviour
{
    bool pressed;
    public float pressDistance, originalPos;

    private void Start()
    {
        originalPos = transform.position.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed)
        {
            pressed = true;
            transform.position = new Vector3(transform.position.x - pressDistance, transform.position.y, transform.position.z);
            //add char to keypad screen
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(pressed)
        {
            transform.position = new Vector3(originalPos, transform.position.y, transform.position.z);
            pressed = false;
        }
    }
}
