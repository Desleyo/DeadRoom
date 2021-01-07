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
        if (collision.gameObject.name == "Deer")
        {
            if (deerTotem.GetComponent<DeerTotem>().deerTotemDone == true)
            {
                mensTotem.transform.localPosition = new Vector3(20.637f, -22.732f, -32.698f);
                mensTotem.transform.rotation = Quaternion.identity;
                mensTotem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                mensTotemDone = true;
            }
        }
    }
}
