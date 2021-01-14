using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DeathEvent : MonoBehaviour
{
    public GameObject player, teleporting, mainDoor, wendigoB, wendigoM;
    public AudioSource heartBeat;

    public void onTimeUp()
    {
        if (player.GetComponent<PlayerController>().room == 0)
        {
            mainDoor.GetComponentInChildren<DoorOpen>().enabled = false;
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoB.SetActive(true);
            wendigoB.GetComponent<Animator>().SetBool("stairWalk", true);
            wendigoB.GetComponent<Attack>().canWalk = false;
            wendigoB.GetComponent<Attack>().stairs = true;
            wendigoB.GetComponent<Attack>().walkTimer = 11f;
            heartBeat.loop = true;
            heartBeat.Play();
        }
        else if(player.GetComponent<PlayerController>().room == 1)
        {
            mainDoor.GetComponentInChildren<DoorOpen>().enabled = false;
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoM.SetActive(true);
            wendigoM.GetComponent<Animator>().SetBool("walk", true);
            wendigoM.GetComponent<Attack>().room = 1;
            heartBeat.loop = true;
            heartBeat.Play();
        }
        else if (player.GetComponent<PlayerController>().room == 2)
        {
            mainDoor.GetComponentInChildren<DoorOpen>().enabled = false;
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoM.transform.eulerAngles = new Vector3(0, 180, 0);
            wendigoM.SetActive(true);
            wendigoM.GetComponent<Animator>().SetBool("walk", true);
            wendigoM.GetComponent<Attack>().room = 2;
            heartBeat.loop = true;
            heartBeat.Play();
        }

        player.GetComponent<PlayerController>().speed = 0;
        teleporting.SetActive(false);
    }
}
