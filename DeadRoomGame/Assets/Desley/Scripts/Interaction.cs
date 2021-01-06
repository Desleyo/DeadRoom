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
    public bool Grab, painting;
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
            if(distance <= .3 && Grab && painting)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                audioSource.Play();
            }
            else if (distance <= .3 && Grab && !painting)
            {
                audioSource.Play();
                gunWithFlag.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
