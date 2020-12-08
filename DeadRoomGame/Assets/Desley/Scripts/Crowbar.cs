using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public GameObject crowbar, door;
    public float distance;
    public bool useable;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, door.transform.position);
        if(distance <= .5f && useable)
        {
            //play sound
            crowbar.SetActive(true);
            Destroy(gameObject);
        }
    }
}
