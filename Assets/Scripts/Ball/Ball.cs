using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public Vector3 Velocity { get { return rb.velocity; }
        set
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
            rb.velocity = value;
        } }
    [SerializeField]
    Stats stats;
    
    // ---- INTERN ----
    private Vector3 movement = Vector3.zero;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(movement * stats.speed);
    }

    public void Move(Vector3 movement)
    {
        this.movement = movement;
    }
}
