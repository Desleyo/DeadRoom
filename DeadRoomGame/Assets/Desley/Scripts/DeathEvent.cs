using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DeathEvent : MonoBehaviour
{
    public GameObject player, teleporting, mainDoor, wendigoB, wendigoM;

    public void onTimeUp()
    {
        if (player.GetComponent<PlayerController>().room == 0)
        {
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoB.SetActive(true);
            wendigoB.GetComponent<Animator>().SetBool("stairWalk", true);
            wendigoB.GetComponent<Attack>().canWalk = false;
            wendigoB.GetComponent<Attack>().stairs = true;
            wendigoB.GetComponent<Attack>().walkTimer = 11f;
        }
        else if(player.GetComponent<PlayerController>().room == 1)
        {
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoM.SetActive(true);
            wendigoM.GetComponent<Animator>().SetBool("walk", true);
            wendigoM.GetComponent<Attack>().canWalk = true;
        }
        else if (player.GetComponent<PlayerController>().room == 2)
        {
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoM.transform.eulerAngles = new Vector3(0, 180, 0);
            wendigoM.SetActive(true);
            wendigoM.GetComponent<Animator>().SetBool("walk", true);
            wendigoM.GetComponent<Attack>().canWalk = false;
        }

        player.GetComponent<PlayerController>().speed = 0;
        teleporting.SetActive(false);
    }
}
