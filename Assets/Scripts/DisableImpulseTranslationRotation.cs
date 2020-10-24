using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableImpulseTranslationRotation : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

        //Stop Moving/Translating
        rigidBody.velocity = Vector3.zero;

        //Stop rotating
        rigidBody.angularVelocity = Vector3.zero;
    }
}
