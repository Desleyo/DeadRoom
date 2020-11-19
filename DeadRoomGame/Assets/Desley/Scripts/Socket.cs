using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Socket : MonoBehaviour
{
    public GameObject item = null;

    // Update is called once per frame
    void Update()
    {
        if(item != null)
        {
            item.transform.position = transform.position;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interactable>())
        {
            item = collision.gameObject;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
