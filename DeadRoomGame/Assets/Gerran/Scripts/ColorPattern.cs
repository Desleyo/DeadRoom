using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ColorPattern : MonoBehaviour
{
    public GameObject[] colorObj;
    public Material[] colorMat;
    public bool canClick, clicked, right, oneTime, done, chestOpen;
    public int controle;
    public float time, baseTime;

    public SteamVR_Action_Boolean input;
    public GameObject controller, closestColor;
    public float distance, closestDistance = Mathf.Infinity;
    public bool currentInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInput = input.state;
        closestDistance = Mathf.Infinity;
        foreach(GameObject color in colorObj)
        {
            distance = Vector3.Distance(controller.transform.position, color.transform.position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestColor = color;
            }
        }

        if (canClick == true)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                clicked = true;
                oneTime = true;
                canClick = false;
            }
        }

        if (clicked == true)
        {
            if (oneTime == true)
            {
                Click();
            }
        }
    }

    public void Click()
    {
        if (right == true)
        {
            if (done == true)
            {

                chestOpen = true;
                colorMat[0].EnableKeyword("_EMISSION");
                colorMat[1].EnableKeyword("_EMISSION");
                colorMat[2].EnableKeyword("_EMISSION");
                colorMat[3].EnableKeyword("_EMISSION");
                colorMat[4].EnableKeyword("_EMISSION");

            }

            else
            {
                if (time >= 0)
                {
                    time -= Time.deltaTime;
                    colorMat[controle].EnableKeyword("_EMISSION");
                }

                else if (time <= 0.00001)
                {
                    colorMat[controle].DisableKeyword("_EMISSION");
                    controle += 1;
                    clicked = false;
                    oneTime = false;
                    right = false;
                    time = baseTime;
                }
            }
        }

        else if (right == false)
        {
            controle = 0;
            if (time >= 0)
            {
                controle = 0;
                time -= Time.deltaTime;
                colorMat[5].EnableKeyword("_EMISSION");
            }
            else if (time <= 0.00001)
            {
                colorMat[5].DisableKeyword("_EMISSION");
                time = baseTime;
                oneTime = false;
            }

        }

    }
}
