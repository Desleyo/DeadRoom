using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public GameObject[] soundPositions;
    public GameObject scratchPos, staringPos;
    public int randomEvent, randomMax;
    public float nextEventTimer, timerMin, timerMax;

    // Update is called once per frame
    void Update()
    {
        nextEventTimer -= Time.deltaTime;

        if(nextEventTimer <= 0)
        {
            randomEvent = Random.Range(0, randomMax);
            nextEventTimer = Random.Range(timerMin, timerMax);
            if(randomEvent >= 0 && randomEvent <= 2)
            {
                PlaySound(randomEvent);
            }
            else
            {
                PlayEvent(randomEvent);
            }
        }
    }

    public void PlaySound(int eventNumber)
    {
        soundPositions[eventNumber].GetComponent<SoundPlayer>().InstantiateSound();
    }

    public void PlayEvent(int eventNumber)
    {
        if(eventNumber == 3)
        {
            scratchPos.GetComponent<StairScratch>().Randomize();
        }
        else if(eventNumber == 4)
        {
            staringPos.GetComponent<StairScratch>().Randomize();
        }
        else if(eventNumber == 5)
        {
            //runBy
        }
    }
}
