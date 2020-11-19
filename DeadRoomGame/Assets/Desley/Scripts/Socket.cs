using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Socket : MonoBehaviour
{
    public GameObject item = null;
    public SteamVR_Action_Boolean input;

    // Update is called once per frame
    void Update()
    {
        if (item == null)
            return;

            item.transform.position = transform.position;
            item.transform.rotation = Quaternion.identity;

        if(item.GetComponent<CollisionCheck>().collisionWithHand == true)
        {
            print("cock");
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
