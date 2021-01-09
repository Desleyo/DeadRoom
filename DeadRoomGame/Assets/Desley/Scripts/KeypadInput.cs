using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInput : MonoBehaviour
{
    bool pressed;
    float originalPos, nextInput;

    public float pressDistance;
    public int number;

    public GameObject canvas;

    private void Start()
    {
        originalPos = transform.position.x;
        nextInput = Mathf.Infinity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pressed)
        {
            transform.position = new Vector3(transform.position.x - pressDistance, transform.position.y, transform.position.z);
            canvas.GetComponent<Code>().charToAdd = number;
            pressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(pressed && nextInput > 0)
        {
            transform.position = new Vector3(originalPos, transform.position.y, transform.position.z);
            nextInput = .3f;
        }
    }

    private void Update()
    {
        nextInput -= Time.deltaTime;
        if(nextInput <= 0)
        {
            pressed = false;
            nextInput = Mathf.Infinity;
        }
    }
}
