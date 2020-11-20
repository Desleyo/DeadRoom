using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    private Moveable storedObject = null;
    private FixedJoint joint = null;

    private void Awake()
    {
        joint = GetComponent<FixedJoint>();
    }

    private void Attach(Moveable newObject)
    {
        if (storedObject)
            return;

        storedObject = newObject;

        storedObject.transform.position = transform.position;
        storedObject.transform.rotation = Quaternion.identity;

        Rigidbody targetBody = storedObject.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;
    }

    private void Detach()
    {
        if (!storedObject)
            return;

        joint.connectedBody = null;
        storedObject = null;
    }

    public Moveable GetStoredObject()
    {
        return storedObject;
    }
}
