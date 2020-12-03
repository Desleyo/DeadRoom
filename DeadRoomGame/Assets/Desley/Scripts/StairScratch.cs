using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScratch : MonoBehaviour
{
    public GameObject player;
    public GameObject[] children;
    public GameObject activeChild;
    public bool hasAnimationToPlay;
    public int randomizer;
    public float timer, actionTime;

    public void Start()
    {
        timer = Mathf.Infinity;
    }

    public void Randomize()
    {
        randomizer = Random.Range(0, children.Length);
        if (hasAnimationToPlay)
        {
            StartScratch();
        }
        else
        {
            StartStair();
        }
    }

    public void StartScratch()
    {
        player.GetComponent<Heartbeat>().startSearching = true;
        children[randomizer].GetComponent<Animator>().SetBool("Scratch", true);
        children[randomizer].SetActive(true);
        activeChild = children[randomizer];
        timer = actionTime;
    }

    public void StartStair()
    {
        player.GetComponent<Heartbeat>().startSearching = true;
        children[randomizer].SetActive(true);
        activeChild = children[randomizer];
        timer = actionTime;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && !hasAnimationToPlay)
        {
            player.GetComponent<Heartbeat>().startSearching = false;
            activeChild.SetActive(false);
            activeChild = null;
            timer = Mathf.Infinity;
        }
        else if(timer <= 0)
        {
            player.GetComponent<Heartbeat>().startSearching = false;
            activeChild.SetActive(false);
            activeChild.GetComponent<Animator>().SetBool("Scratch", false);
            activeChild = null;
            timer = Mathf.Infinity;
        }
    }
}
