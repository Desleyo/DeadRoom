using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Inventory : MonoBehaviour
{
    public GameObject item = null;
    public SteamVR_Action_Boolean detach;
    public GameObject hand;
    public bool detaching;

    // Update is called once per frame
    void Update()
    {
        detaching = detach.state;

        if (item == null)
        {
            return;
        }

        if(detaching)
        {
            item.transform.position = hand.transform.position;
            item = null; 
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<SphereCollider>().enabled = true;
            return;
        }

        item.transform.position = transform.position;
        item.transform.rotation = Quaternion.identity;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() && item == null)
        {
            item = other.gameObject;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
