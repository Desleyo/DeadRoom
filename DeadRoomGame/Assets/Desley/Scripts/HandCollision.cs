using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;

    public bool collisionWithHand;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == rightHand)
        {
            collisionWithHand = true;
        }
        else if(other.gameObject == leftHand)
        {
            collisionWithHand = true;
        }
    }
}
