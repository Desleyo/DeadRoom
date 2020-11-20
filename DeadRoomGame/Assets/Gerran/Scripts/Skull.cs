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
        if (collision.gameObject.name == "DeerTotem")
        {
            if (deerTotem.GetComponent<DeerTotem>().deerTotemDone == true)
            {
                skull.transform.position = new Vector3(deerTotem.transform.position.x, deerTotem.transform.position.y + 1, deerTotem.transform.position.z);
                skull.transform.rotation = Quaternion.identity;
                skull.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                skullDone = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "DeerTotem")
        {
            skullDone = false;
        }
    }
}
