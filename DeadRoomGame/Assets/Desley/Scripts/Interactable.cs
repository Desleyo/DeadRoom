using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isAvailable = true;

    public virtual void StartInteraction(Hands hand)
    {
        print("start");
    }

    public virtual void Interaction(Hands hand)
    {
        print("interaction");
    }

    public virtual void EndInteraction(Hands hand)
    {
        print("end");
    }

    public bool GetAvailability()
    {
        return isAvailable;
    }
}
