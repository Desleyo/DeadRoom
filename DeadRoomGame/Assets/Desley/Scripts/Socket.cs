﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Socket : MonoBehaviour
{
    public GameObject item = null;
    public SteamVR_Action_Boolean input;

    public bool once;

    // Update is called once per frame
    void Update()
    {
        if (item == null)
            return;
        
        if (!once)
        {
            item.transform.position = transform.position;
            item.transform.rotation = Quaternion.identity;
            once = true;
        }

        if(item.GetComponent<HandCollision>().collisionWithHand == true)
        {

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() && item == null)
        {
            item = collision.gameObject;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
