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
         timer = GameObject.FindWithTag("timer");
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
        if(collision.gameObject.name == "Standard")
        {
            deerTotem.transform.localPosition = new Vector3(20.633f, -22.57f, -32.511f);
            deerTotem.transform.localRotation = Quaternion.Euler(0, 180, 0);
            deerTotem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            deerTotemDone = true;
        }
    }

    public void AddTime()
    {
        timer.GetComponent<Timer>().min += addNum;
        source.PlayOneShot(sound);
        addedTime = false;
    }
}
