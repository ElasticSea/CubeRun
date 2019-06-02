using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardVelocity = 50;
    public float sidewaysVelocity = 10;
    public float jumpForce = 1000;
    [SerializeField] private bool alive = true;

    public event Action OnDeathEvent = () => { };

    public bool Alive => alive;

    void Awake()
    {
        // Move center of mass lower to ground, so the cube does not tumble
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0,-.5f, 0);
    }

    private void Update()
    {
        if (Alive == false) return;

        var isTouchingGround = Physics.Linecast(transform.position , transform.position + Vector3.down * .51f);
        
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }

        // Ensure that cube does not rotate sideways
        var rotation = transform.rotation.eulerAngles;
        rotation.y = 0;
        transform.rotation = Quaternion.Euler(rotation);
    }

    void FixedUpdate()
    {
        if (Alive == false) return;
        
        var rb = GetComponent<Rigidbody>();
        
        var sideways = Input.GetAxis("Horizontal") * sidewaysVelocity;
        var forward = forwardVelocity;
        rb.velocity = new Vector3(sideways, rb.velocity.y, forward);
    }

    public void Die()
    {
        alive = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        OnDeathEvent();
    }
}
