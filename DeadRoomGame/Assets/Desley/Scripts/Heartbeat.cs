using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject activeTarget, cam;
    public bool startSearching;
    public float dot;

    // Update is called once per frame
    void Update()
    {
        if (startSearching)
        {
            foreach (GameObject target in targets)
            {
                if (target.activeSelf == true)
                {
                    activeTarget = target;
                    startSearching = false;
                }
            }

        }

        if (activeTarget != null)
        {
            Vector3 dir = (activeTarget.transform.position - cam.transform.position).normalized;
            dot = Vector3.Dot(dir, cam.transform.forward);

            if (dot >= .3f)
            {
                GetComponent<AudioSource>().Play();
                activeTarget = null;
            }
        }
    }
}
