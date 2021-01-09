using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Code : MonoBehaviour
{
    public string code, clear;

    int charToAdd = -1, characters;
    bool cleared;
    float clearTimer;

    Text text;

    public GameObject key;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cleared && clearTimer == Mathf.Infinity)
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

        clearTimer -= Time.deltaTime;
        if (clearTimer <= 0)
        {
            clearTimer = Mathf.Infinity;
            text.color = Color.white;
            text.text = clear;
            characters = 0;
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
            text.color = Color.red;
            clearTimer = .5f;
        }
    }
}
