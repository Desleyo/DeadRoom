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
        if (player.GetComponent<PlayerController>().inBasement == true)
        {
            //activate stairs wendigo
        }
        else
        {
            mainDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            wendigoM.SetActive(true);
        }

        player.GetComponent<PlayerController>().speed = 0;
        teleporting.SetActive(false);
    }
}
