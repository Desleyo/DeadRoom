using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public SteamVR_Action_Vector2 input;
    public int room;
    public float speed = 1, fade;
    public bool fadedFromBlack;
    public GameObject canvas;
    public Image image;
    public Color alpha;

    public Transform checkPoint;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        alpha.a = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadedFromBlack)
        {
            alpha = image.GetComponent<Image>().color;
            alpha.a -= fade * Time.deltaTime;
            image.GetComponent<Image>().color = alpha;
            if (alpha.a <= 0)
            {
                canvas.SetActive(false);
                fadedFromBlack = true;
            }
        }

        if (input.axis.magnitude > .1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        }

        if(checkPoint.position.z > transform.position.z)
        {
            room = 2;
        }
        else if(checkPoint.position.y > transform.position.y)
        {
            room = 0;
        }
        else if(checkPoint.position.z < transform.position.z && checkPoint.position.y < transform.position.y)
        {
            room = 1;
        }
    }
}
