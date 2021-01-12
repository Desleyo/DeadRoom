using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTracker : MonoBehaviour
{
    GameObject eventPlayer;
    public List <Transform> transforms;
    public bool crowbarFound, letterCodeFound, fireExtinguished, gunFired;
    public float crowbarTimer = Mathf.Infinity, fireTimer = Mathf.Infinity, gunTimer = Mathf.Infinity, escapeTimer = Mathf.Infinity, letterTimer = Mathf.Infinity;
    int letter;
    bool gunTimerUp;

    void Start()
    {
        eventPlayer = GameObject.FindGameObjectWithTag("eventPlayer");
    }

    private void Update()
    {
        Timers();

        if (transforms != null)
        {
            foreach (Transform objects in transforms)
            {
                float distance = Vector3.Distance(transform.position, objects.position);
                if(distance <= 1 && objects.tag == "door")
                {
                    eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(0);
                    transforms.Remove(objects);
                    crowbarTimer = 60;
                }
                else if (distance <= .5 && objects.tag == "letterCode" && !letterCodeFound)
                {
                    transforms.Remove(objects);
                    letterCodeFound = true;
                    letter = 1;
                    letterTimer = 5;
                }
                else if (distance <= 1 && objects.tag == "kabinet" && letterCodeFound)
                {
                    eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(4);
                    transforms.Remove(objects);
                }
                else if (distance <= 1 && objects.tag == "gun" && gunTimerUp)
                {
                    eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(5);
                    transforms.Remove(objects);
                }
                else if (distance <= .5 && objects.tag == "letterFriends")
                {
                    transforms.Remove(objects);
                    letter = 2;
                    letterTimer = 10;
                }
                else if (distance <= .5 && objects.tag == "letterPrologue")
                {
                    transforms.Remove(objects);
                    letter = 3;
                    letterTimer = 5;
                }
                else if (distance <= .5 && objects.tag == "letterEntry3")
                {
                    transforms.Remove(objects);
                    letter = 4;
                    letterTimer = 5;
                }
            }
        }
    }
    
    void Timers()
    {
        crowbarTimer -= Time.deltaTime;
        if(crowbarTimer <= 0 && !crowbarFound)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(1);
            crowbarTimer = Mathf.Infinity;
        }

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0 && !fireExtinguished)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(3);
            fireTimer = Mathf.Infinity;
        }

        gunTimer -= Time.deltaTime;
        if (gunTimer <= 0)
        {
            gunTimerUp = true;
            gunTimer = Mathf.Infinity;
        }

        escapeTimer -= Time.deltaTime;
        if (escapeTimer <= 0 && gunFired)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(6);
            escapeTimer = Mathf.Infinity;
        }

        letterTimer -= Time.deltaTime;
        if (letterTimer <= 0 && letter == 1)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(2);
            letterTimer = Mathf.Infinity;
        }
        else if (letterTimer <= 0 && letter == 2)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(7);
            letterTimer = Mathf.Infinity;
        }
        else if (letterTimer <= 0 && letter == 3)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(8);
            letterTimer = Mathf.Infinity;
        }
        else if (letterTimer <= 0 && letter == 4)
        {
            eventPlayer.GetComponent<VoicelinePlayer>().PlayVoiceline(9);
            letterTimer = Mathf.Infinity;
        }
    }
}
