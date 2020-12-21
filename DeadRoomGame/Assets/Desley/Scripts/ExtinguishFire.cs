using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ExtinguishFire : MonoBehaviour
{
    public AudioSource audioSource;
    public SteamVR_Action_Boolean Trigger;
    public GameObject[] hands;
    public GameObject fire;
    public bool Grab;
    public float distance = Mathf.Infinity;

    // Update is called once per frame
    void Update()
    {
        Grab = Trigger.state;
        distance = Mathf.Infinity;

        foreach (GameObject hand in hands)
        {
            distance = Vector3.Distance(transform.position, hand.transform.position);
            if (distance <= .3 && Grab)
            {
                //play particle
                fire.SetActive(false);
                audioSource.Play();
            }
        }
    }
}