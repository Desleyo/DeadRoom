using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Socket : MonoBehaviour
{
    public GameObject item = null;
    public SteamVR_Action_Boolean grab;
    public bool grabbing;

    // Update is called once per frame
    void Update()
    {
        grabbing = grab.state;

        if (item == null)
            return;

        if(item.GetComponent<HandCollision>().collisionWithHand == true && grabbing)
        {
            item = null;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            return;
        }

        item.transform.position = transform.position;
        item.transform.rotation = Quaternion.identity;
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
