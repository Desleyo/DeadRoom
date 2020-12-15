using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float sec, min;
    public GameObject gameoverPanel, eventPlayer;
    public Text secText, minText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sec >= 0)
        {
            sec -= Time.deltaTime;
        }

        else if (sec <= 0.0001)
        {
            if (min >= 0.0001)
            {
                min -= 1;
                sec = 60;
            }

            else if(min == 0)
            {
                eventPlayer.GetComponent<DeathEvent>().onTimeUp();
            }
        }

        secText.text = sec.ToString("F0");
        minText.text = min.ToString(min + ":");
    }
}
