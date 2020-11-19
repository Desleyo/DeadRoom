using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool collisionWithHand;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hand")
        {
            collisionWithHand = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collisionWithHand == true)
        {
            collisionWithHand = false;
        }
    }
}
