using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Key : MonoBehaviour
{
    public GameObject keyHole;
    public float distance;
    public bool unlocked;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, keyHole.transform.position);
        if(distance <= .3f && !unlocked)
        {
            //play sound
            unlocked = true;
            keyHole.GetComponentInParent<CircularDrive>().maxAngle = 90f;        
        }
    }
}
