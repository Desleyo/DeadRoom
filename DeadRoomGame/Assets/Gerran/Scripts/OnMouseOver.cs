using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    public GameObject[] hands;

    private void Update()
    {
        if (hands[] == null)
        {
            hands = GameObject.FindGameObjectsWithTag("Hand");
        }
        if (hands[] == null)
            return;

        foreach(GameObject hand in hands)
        {
            float distance = Vector3.Distance(transform.position, hand.transform.position);
            if(distance <= .5f)
            {
                GetComponent<Outline>().OutlineWidth = 10;
            }
            else
            {
                GetComponent<Outline>().OutlineWidth = 0;
            }
        }
    }
}
