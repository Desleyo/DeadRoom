using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public GameObject skull, deerTotem;
    public bool skullDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Deer")
        {
            if (deerTotem.GetComponent<DeerTotem>().deerTotemDone == true)
            {
                skull.transform.localPosition = new Vector3(0, 0.21f, 0.01f);
                skull.transform.rotation = Quaternion.identity;
                skull.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                skullDone = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Deer")
        {
            skullDone = false;
        }
    }
}
