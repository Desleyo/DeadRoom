using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    public GameObject[] hands;

    private void Update()
    {
        if (hands == null)
        {
            hands = GameObject.FindGameObjectsWithTag("Hand");
        }
        if (hands == null)
            return;

        /*foreach(GameObject hand in hands)
        {
            float distance = Vector3.Distance(transform.position, hand.transform.position);
            if(distance <= .2)
            {
                GetComponent<Outline>().OutlineWidth = 10;
            }
            else
            {
                GetComponent<Outline>().OutlineWidth = 0;
            }
        }*/

        float distanceLeft = Vector3.Distance(transform.position, hands[1].transform.position);
        if(distanceLeft <= .2)
        {
            GetComponent<Outline>().OutlineWidth = 10;
        }
        else
        {
            GetComponent<Outline>().OutlineWidth = 0;
        }

        float distanceRight = Vector3.Distance(transform.position, hands[0].transform.position);
        if (distanceRight <= .2)
        {
            GetComponent<Outline>().OutlineWidth = 10;
        }
        else
        {
            GetComponent<Outline>().OutlineWidth = 0;
        }
    }
}
