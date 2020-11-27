using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hand")
        {
            GetComponent<Outline>().OutlineWidth = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Hand")
        {
            GetComponent<Outline>().OutlineWidth = 0;
        }
    }
}
