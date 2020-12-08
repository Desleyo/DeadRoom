using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DropPainting : MonoBehaviour
{
    public SteamVR_Action_Boolean Trigger;
    public bool Grab, handCollision;

    // Update is called once per frame
    void Update()
    {
        Grab = Trigger.state;

        if (Grab && handCollision)
        {
                GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hand")
        {
            handCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Hand")
        {
            handCollision = false;
        }
    }
}
