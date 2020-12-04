using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFlame : MonoBehaviour
{
    public GameObject flame, glow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flame.transform.rotation = Quaternion.identity;
        glow.transform.rotation = Quaternion.identity;
    }
}
