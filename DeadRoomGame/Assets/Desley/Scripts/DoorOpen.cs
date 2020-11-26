using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DoorOpen : MonoBehaviour
{
    [Header("not required when using crowbar on door")]
    public GameObject key;
    [Header("not required when using key on door")]
    public GameObject crowbar;

    public float timer = Mathf.Infinity;
    public bool doorBroken;

    public void DoorRotationKey()
    {
        GetComponentInParent<CircularDrive>().maxAngle = 90f;
            key.transform.SetParent(transform);
            key.GetComponent<Collider>().enabled = false;
    }

    public void DoorRotationCrowbar()
    {
        GetComponentInParent<CircularDrive>().minAngle = -90f;
        crowbar.GetComponentInChildren<Rigidbody>().useGravity = true;
        crowbar.GetComponentInChildren<Collider>().isTrigger = false;
        timer = 1;
        doorBroken = true;
    }

    public void Update()
    {
        timer -= Time.deltaTime;      
        if(timer <= 0 && doorBroken)
        {
            crowbar.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            timer = Mathf.Infinity;
            doorBroken = false;
        }
    }
}