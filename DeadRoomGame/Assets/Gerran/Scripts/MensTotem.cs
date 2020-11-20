using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensTotem : MonoBehaviour
{
    public GameObject mensTotem, deerTotem;
    public bool mensTotemDone;

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
                mensTotem.transform.position = new Vector3(deerTotem.transform.position.x, deerTotem.transform.position.y, deerTotem.transform.position.z - 1);
                mensTotem.transform.rotation = Quaternion.identity;
                mensTotem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                mensTotemDone = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "DeerTotem")
        {
            mensTotemDone = false;
        }
    }
}
