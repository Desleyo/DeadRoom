using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInput : MonoBehaviour
{
    bool pressed;
    public float pressDistance, originalPosZ;

    private void Start()
    {
        originalPosZ = transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed)
        {
            pressed = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - pressDistance);
            //add char to keypad screen
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(pressed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, originalPosZ);
            pressed = false;
        }
    }
}
