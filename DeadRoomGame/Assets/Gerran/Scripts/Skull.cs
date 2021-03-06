﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public GameObject skull, deerTotem;
    public bool skullDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Deer")
        {
            if (deerTotem.GetComponent<DeerTotem>().deerTotemDone == true)
            {
                skull.transform.localPosition = new Vector3(20.6263f, -22.1767f, -32.566f);
                skull.transform.localRotation = Quaternion.Euler(0, 180, 0);
                skull.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                skullDone = true;
            }
        }
    }
}
