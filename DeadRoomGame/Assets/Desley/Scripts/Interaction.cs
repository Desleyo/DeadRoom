using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Interaction : MonoBehaviour
{
    public AudioSource audioSource;
    public SteamVR_Action_Boolean Trigger;
    public GameObject[] hands;
    public bool Grab, painting, done;
    public float distance = Mathf.Infinity;

    [Header("not required when interacting with painting")]
    public GameObject gunWithFlag;

    // Update is called once per frame
    void Update()
    {
        Grab = Trigger.state;
        distance = Mathf.Infinity;

        foreach (GameObject hand in hands)
        {
            distance = Vector3.Distance(transform.position, hand.transform.position);
            if(distance <= .3 && Grab && painting && !done)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Outline>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<HintTracker>().paintingDropped = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<HintTracker>().fireTimer = 60;
                audioSource.Play();
                done = true;
            }
            else if (distance <= .3 && Grab && !painting && !done)
            {
                audioSource.Play();
                GameObject.FindGameObjectWithTag("Player").GetComponent<HintTracker>().gunFired = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<HintTracker>().escapeTimer = 10;
                gunWithFlag.SetActive(true);
                gameObject.SetActive(false);
                done = true;
            }
        }
    }
}
