using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DoorOpen : MonoBehaviour
{
    public GameObject key, fakeKey;
    public void DoorRotationActive()
    {
        key.SetActive(false);
        fakeKey.SetActive(true);
        GetComponentInParent<CircularDrive>().maxAngle = 90f;
    }
}