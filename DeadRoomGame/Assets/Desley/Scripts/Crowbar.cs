using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public GameObject crowbar, point;
    Transform originalPos;
    public float distance;
    public bool useable = true;

    void Start()
    {
        originalPos = transform;
    }

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

        if(transform != originalPos)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HintTracker>().crowbarFound = true;
        }
    }
}
