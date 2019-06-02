using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardVelocity = 50;
    public float sidewaysVelocity = 10;
    
    void Awake()
    {
        // Move center of mass lower to ground, so the cube does not tumble
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0,-.5f, 0);
    }

    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        
        var sideways = Input.GetAxis("Horizontal") * sidewaysVelocity;
        var forward = forwardVelocity;
        rb.velocity = new Vector3(sideways, rb.velocity.y, forward);
    }
}
