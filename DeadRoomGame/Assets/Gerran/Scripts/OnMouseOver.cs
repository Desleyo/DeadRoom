using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Outline>().OutlineWidth = 10;
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Outline>().OutlineWidth = 0;
    }
}
