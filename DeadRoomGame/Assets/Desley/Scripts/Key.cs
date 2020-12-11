using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Key : MonoBehaviour
{
    public GameObject key, keyhole;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, keyhole.transform.position);
        if(distance <= .3f)
        {
            if(gameObject.tag == "Fusebox Key")
            {
                keyhole.transform.SetParent(key.transform);
            }
            key.SetActive(true);
            Destroy(gameObject);
        }
    }
}
