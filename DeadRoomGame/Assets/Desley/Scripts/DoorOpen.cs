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
    [Header("not required when using key on door")]
    public GameObject bedroomTP;

    public GameObject eventPlayer;

    public float timer = Mathf.Infinity;
    public bool doorBroken, frontDoor;
    public int angle;

    public void DoorFuseBox()
    {
        GetComponentInParent<CircularDrive>().maxAngle = angle;
        key.GetComponent<Collider>().enabled = false;
    }

    public void DoorRotationKey()
    {
        GetComponentInParent<CircularDrive>().minAngle = angle;
        key.GetComponentInChildren<Collider>().enabled = false;
    }

    public void DoorRotationCrowbar()
    {
        GetComponentInParent<CircularDrive>().minAngle = angle;
        bedroomTP.GetComponent<TeleportArea>().locked = false;
        crowbar.GetComponentInChildren<Collider>().isTrigger = false;
        crowbar.GetComponentInChildren<Rigidbody>().useGravity = true;
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

        if(GetComponentInParent<Transform>().rotation.y < 0 && frontDoor)
        {
            eventPlayer.GetComponent<End>().SetTimer();
            frontDoor = false;
        }
    }
}