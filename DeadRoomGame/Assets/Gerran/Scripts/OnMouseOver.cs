using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GetComponent<Outline>().OutlineWidth = 10;
    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().OutlineWidth = 0;
    }
}
