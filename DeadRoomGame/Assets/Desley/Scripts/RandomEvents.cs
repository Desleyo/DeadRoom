using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] soundPositions;
    public GameObject scratchPos, staringPos, wendigoPos;
    public int randomEvent, randomMin, randomMax;
    public float gameTimer, nextEventTimer, timerMin, timerMax;
    public bool devMode, playable = true;

    private void Start()
    {
        if(canvas.GetComponent<Timer>().min <= 10)
        {
            devMode = true;
        }
        else
        {
            devMode = false;
        }

        if (!devMode)
        {
            nextEventTimer = 120f;
        }
        else
        {
            nextEventTimer = 60f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextEventTimer -= Time.deltaTime;
        gameTimer = canvas.GetComponent<Timer>().min;

        if (gameTimer == 0 && canvas.GetComponent<Timer>().sec <= 30)
        {
            playable = false;
        }

        if (!devMode)
        {
            if (gameTimer >= 12)
            {
                randomMin = 0;
                randomMax = 5;
            }
            else
            {
                randomMin = 5;
                randomMax = 14;
            }
        }
        else
        {
            if (gameTimer >= 6)
            {
                randomMin = 0;
                randomMax = 5;
            }
            else
            {
                randomMin = 5;
                randomMax = 14;
            }
        }

        if(nextEventTimer <= 0 && playable)
        {
            randomEvent = Random.Range(randomMin, randomMax);
            nextEventTimer = Random.Range(timerMin, timerMax);
            if(randomEvent >= 0 && randomEvent <= 7)
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
        soundPositions[eventNumber].GetComponent<AudioSource>().Play();
    }

    public void PlayEvent(int eventNumber)
    {
        if(eventNumber >= 8 && eventNumber <=9)
        {
            scratchPos.GetComponent<StairScratch>().Randomize();
            GetComponent<VoicelinePlayer>().OnWendigoAppear();
        }
        else if(eventNumber >= 10 && eventNumber <= 11)
        {
            staringPos.GetComponent<StairScratch>().Randomize();
            GetComponent<VoicelinePlayer>().OnWendigoAppear();
        }
        else if(eventNumber >= 12 && eventNumber <= 13)
        {
            wendigoPos.SetActive(true);
            wendigoPos.GetComponent<WalkBy>().reset = false;
            GetComponent<VoicelinePlayer>().OnWendigoAppear();
        }
    }
}
