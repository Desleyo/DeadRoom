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
    public GameObject controller, closestColor, collerPattern, chest;
    public float distance, closestDistance = Mathf.Infinity;
    public bool currentInput;

    // Update is called once per frame
    void Update()
    {
        currentInput = input.state;
        closestDistance = Mathf.Infinity;
        foreach (GameObject color in colorObj)
        {
            distance = Vector3.Distance(controller.transform.position, color.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestColor = color;
            }
        }

        if(canClick == false && closestDistance <= 1)
        {
            canClick = true;
        }

        if (canClick == true)
        {
            if(currentInput && closestDistance <= 1)
            {
                if (closestColor.tag == "Color1")
                {
                    if (controle == 0)
                    {
                        right = true;
                    }
                }
                else if(closestColor.tag == "Color2")
                {
                    if (controle == 1)
                    {
                        right = true;
                    }
                }
                else if (closestColor.tag == "Color3")
                {
                    if (controle == 2)
                    {
                        right = true;
                    }
                }
                else if (closestColor.tag == "Color4")
                {
                    if (controle == 3)
                    {
                        right = true;
                    }
                }
                clicked = true;
                oneTime = true;
                canClick = false;
            }
        }

        if (clicked == true && !chestOpen)
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
                if (time >= 0)
                {
                    time -= Time.deltaTime;
                    chestOpen = true;
                    colorMat[0].EnableKeyword("_EMISSION");
                    colorMat[1].EnableKeyword("_EMISSION");
                    colorMat[2].EnableKeyword("_EMISSION");
                    colorMat[3].EnableKeyword("_EMISSION");
                    colorMat[4].EnableKeyword("_EMISSION");
                }

                else if (time <= 0.00001)
                {
                    colorMat[0].DisableKeyword("_EMISSION");
                    colorMat[1].DisableKeyword("_EMISSION");
                    colorMat[2].DisableKeyword("_EMISSION");
                    colorMat[3].DisableKeyword("_EMISSION");
                    colorMat[4].DisableKeyword("_EMISSION");
                    collerPattern.SetActive(false);
                    chest.GetComponent<CircularDrive>().minAngle = -50;
                }

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
                    if(controle == 3)
                    {
                        done = true;
                    }
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
