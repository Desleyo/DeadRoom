using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Code : MonoBehaviour
{
    public int charToAdd = -1, characters;
    public string code, clear;
    public bool cleared;
    Text text;

    public GameObject key;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cleared)
        {
            if (charToAdd != -1)
            {
                text.text += charToAdd;
                characters += 1;
                charToAdd = -1;
            }

            if (characters == 4)
            {
                CheckCode();
            }
        }
    }

    private void CheckCode()
    {
        if(text.text == code)
        {
            cleared = true;
            text.color = Color.green;
            key.GetComponent<CircularDrive>().minAngle = -90;
        }
        else
        {
            text.text = clear;
            characters = 0;
        }
    }
}
