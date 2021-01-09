using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInput : MonoBehaviour
{
    bool pressed;
    public float pressDistance, originalPosY;

    private void Start()
    {
        originalPosY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed)
        {
            pressed = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - pressDistance, transform.position.z);
            //add char to keypad screen
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(pressed)
        {
            transform.position = new Vector3(transform.position.x, originalPosY, transform.position.z);
            pressed = false;
        }
    }
}
