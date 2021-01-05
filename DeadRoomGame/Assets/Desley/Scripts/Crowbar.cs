using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public GameObject crowbar, point;
    public float distance;
    public bool useable = true;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, point.transform.position);
        if(distance <= .75f && useable)
        {
            //play sound
            crowbar.SetActive(true);
            Destroy(gameObject);
        }
    }
}
