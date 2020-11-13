using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        player.GetComponent<ColorPattern>().canClick = true;
        if (player.GetComponent<ColorPattern>().controle == 0)
        {
            if (tag == "Color1")
            {
                player.GetComponent<ColorPattern>().right = true;
            }

            else
            {
                player.GetComponent<ColorPattern>().right = false;
            }
        }
        if (player.GetComponent<ColorPattern>().controle == 1)
        {
            if (tag == "Color2")
            {
                player.GetComponent<ColorPattern>().right = true;
            }

            else
            {
                player.GetComponent<ColorPattern>().right = false;
            }
        }
        if (player.GetComponent<ColorPattern>().controle == 2)
        {
            if (tag == "Color3")
            {
                player.GetComponent<ColorPattern>().right = true;
            }

            else
            {
                player.GetComponent<ColorPattern>().right = false;
            }
        }
        if (player.GetComponent<ColorPattern>().controle == 3)
        {
            if (tag == "Color4")
            {
                player.GetComponent<ColorPattern>().right = true;
                player.GetComponent<ColorPattern>().done = true;
            }

        else
            {
                player.GetComponent<ColorPattern>().right = false;
            }
        }
    }
}
