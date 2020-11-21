﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //play sound
            key.SetActive(true);
            Destroy(gameObject);
        }
    }
}
