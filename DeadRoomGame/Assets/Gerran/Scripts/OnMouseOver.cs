using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    public GameObject[] hands;
    public bool leftOutline, rightOutline;
    private void Update()
    {
        if (hands == null)
        {
            hands = GameObject.FindGameObjectsWithTag("Hand");
        }
        if (hands == null)
            return;

        float distanceRight = Vector3.Distance(transform.position, hands[1].transform.position);
        if (distanceRight <= .2)
        {
            GetComponent<Outline>().OutlineWidth = 10;
            rightOutline = true;
        }
        else if (!leftOutline)
        {
            GetComponent<Outline>().OutlineWidth = 0;
            rightOutline = false;
        }

        float distanceLeft = Vector3.Distance(transform.position, hands[0].transform.position);
        if (distanceLeft <= .2)
        {
            GetComponent<Outline>().OutlineWidth = 10;
            leftOutline = true;
        }
        else if(!rightOutline)
        {
            GetComponent<Outline>().OutlineWidth = 0;
            leftOutline = false;
        }

        if(distanceRight > .2 && distanceLeft > .2)
        {
            GetComponent<Outline>().OutlineWidth = 0;
            leftOutline = false;
            rightOutline = false;
        }
    }
}
