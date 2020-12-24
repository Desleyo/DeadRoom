using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FireExtinguisher : MonoBehaviour
{
    public Transform firePos;
    public GameObject extinguisher;

    public AudioSource audioSource;
    public SteamVR_Action_Boolean Trigger;
    public GameObject[] hands;
    public GameObject fire;
    public bool grab, done;
    public float distance = Mathf.Infinity;

    public bool switched;
    // Update is called once per frame
    void Update()
    {
        if (!switched)
        {
            float distance = Vector3.Distance(transform.position, firePos.position);
            if (distance <= 1)
            {
                extinguisher.SetActive(true);
                extinguisher.GetComponent<FireExtinguisher>().switched = true;
                Destroy(gameObject);
            }
        }
        else
        {
            grab = Trigger.state;
            distance = Mathf.Infinity;
            foreach (GameObject hand in hands)
            {
                distance = Vector3.Distance(transform.position, hand.transform.position);
                if (distance <= .6 && grab && !done)
                {
                    //play particle
                    fire.SetActive(false);
                    audioSource.Play();
                    done = true;
                }
            }
        }
    }
}