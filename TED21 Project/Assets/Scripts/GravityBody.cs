using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    // Declears the varibles
    GravityAttractor planet;
    Rigidbody rb;

    void Awake()
    {
        // Get the planet object if i tag it with planet
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rb = GetComponent<Rigidbody>();

        // Disable normal gravity and use the gravity created with my code
        rb.useGravity = false;
        // Makes the body not rotate normally only make it change if i tell it to
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Make the body use my gravity each update (Game tick)
        planet.Attract(rb);
    }
}
