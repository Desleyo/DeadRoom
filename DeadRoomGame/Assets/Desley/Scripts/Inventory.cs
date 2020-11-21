using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Inventory : MonoBehaviour
{
    public GameObject item = null;
    public Rigidbody itemRigidbody = null;
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
            item.GetComponent<AfterPickup>().timer = 1f;
            itemRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            item.GetComponent<Collider>().enabled = true;
            item = null;
            itemRigidbody = null;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<SphereCollider>().enabled = true;
            return;
        }

        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() && item == null)
        {
            item = other.gameObject;
            itemRigidbody = item.GetComponent<Rigidbody>();
            item.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
