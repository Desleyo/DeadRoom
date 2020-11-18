using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Key : MonoBehaviour
{
    public GameObject key, keylessHole, keyhole;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, keylessHole.transform.position);
        if(distance <= .3f)
        {
            //play sound
            keylessHole.SetActive(false);
            keyhole.SetActive(true);
            key.SetActive(true);
            Destroy(gameObject);
        }
    }
}
