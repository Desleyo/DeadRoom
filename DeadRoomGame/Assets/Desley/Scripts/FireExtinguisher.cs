using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public Transform firePos;
    public GameObject extinguisher;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, firePos.position);
        if(distance <= 1)
        {
            extinguisher.SetActive(true);
            Destroy(gameObject);
        }
    }
}
