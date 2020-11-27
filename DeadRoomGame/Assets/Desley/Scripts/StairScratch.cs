using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScratch : MonoBehaviour
{
    public GameObject[] children;
    public GameObject activeChild, player;
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
            StartEvent();
        }
        else
        {
            player.GetComponent<AudioSource>().Play();
            children[randomizer].SetActive(true);
            activeChild = children[randomizer];
            timer = actionTime;
        }
    }

    public void StartEvent()
    {
        children[randomizer].SetActive(true);
        activeChild = children[randomizer];
        children[randomizer].GetComponent<Animator>().SetBool("Scratch", true);
        timer = actionTime;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && !hasAnimationToPlay)
        {
            activeChild.SetActive(false);
            activeChild = null;
            timer = Mathf.Infinity;
        }
        else if(timer <= 0)
        {
            activeChild.SetActive(false);
            activeChild.GetComponent<Animator>().SetBool("Scratch", false);
            activeChild = null;
            timer = Mathf.Infinity;
        }
    }
}
