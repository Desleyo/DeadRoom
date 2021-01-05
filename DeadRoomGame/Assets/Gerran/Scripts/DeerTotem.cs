using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerTotem : MonoBehaviour
{
    public GameObject altar, deerTotem, mensTotem, skull, timer;
    public bool deerTotemDone, addedTime;
    public int addNum;
    public AudioClip sound;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deerTotemDone == true)
        {
            if (mensTotem.GetComponent<MensTotem>().mensTotemDone == true)
            {
                if (skull.GetComponent<Skull>().skullDone == true)
                {
                    if (addedTime == true)
                    {
                        AddTime();
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "altar")
        {
            deerTotem.transform.position = new Vector3(altar.transform.position.x, altar.transform.position.y + .5f, altar.transform.position.z);
            deerTotem.transform.rotation = Quaternion.identity;
            deerTotem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            deerTotemDone = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "altar")
        {
            deerTotemDone = (false);
        }
    }

    public void AddTime()
    {
        timer.GetComponent<Timer>().min += addNum;
        source.PlayOneShot(sound);
        addedTime = false;
    }
}
