using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBy : MonoBehaviour
{
    public GameObject startPos, endPos, player;
    public float speed;
    public bool reset;

    // Update is called once per frame
    void Update()
    {
        if (!reset)
        {
            transform.position = startPos.transform.position;
            GetComponent<Animator>().SetBool("walk", true);
            player.GetComponent<Heartbeat>().startSearching = true;
            player.GetComponent<AudioSource>().loop = true;
            reset = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, speed * Time.deltaTime);

        if(transform.position == endPos.transform.position)
        {
            GetComponent<Animator>().SetBool("walk", false);
            player.GetComponent<Heartbeat>().startSearching = false;
            player.GetComponent<AudioSource>().loop = false;
            gameObject.SetActive(false);
        }
    }
}
