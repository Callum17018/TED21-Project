using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    //Declares the gravity varible
    public float gravity = -10f;
    
    public void Attract(Rigidbody body)
    {
        //Make vec3 varibles for rotating and position
        Vector3 targetDirection = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.transform.up;

        // Apply downwards gravity to body
        body.AddForce(bodyUp * gravity);
        // Change rotation so that the player is facing upwards
        body.rotation = Quaternion.FromToRotation(bodyUp, targetDirection) * body.rotation;

    }
}
