using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPickup : MonoBehaviour
{
    Rigidbody itemRigidbody;
    public float timer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        itemRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            itemRigidbody.constraints = RigidbodyConstraints.None;
            timer = Mathf.Infinity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand" && timer <=.5f)
        {
            timer = 0;
        }
    }
}
