using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Inventory : MonoBehaviour
{
    public GameObject item = null;
    public SteamVR_Action_Boolean grab;
    public GameObject[] hands;
    GameObject closestHand = null;
    public float distance = Mathf.Infinity, closestDistance = Mathf.Infinity;
    public bool grabbing;

    // Update is called once per frame
    void Update()
    {
        grabbing = grab.state;

        if (item == null)
        {
            return;
        }

        distance = Mathf.Infinity;
        closestDistance = Mathf.Infinity;
        closestHand = null;

        foreach (GameObject hand in hands)
        {
            distance = Vector3.Distance(hand.transform.position, item.transform.position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestHand = hand;
            }
        }

        if(item.GetComponent<HandCollision>().collisionWithHand == true && grabbing)
        {
            item.transform.position = closestHand.transform.position;
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
