using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperManager : MonoBehaviour
{
    [SerializeField] public float magnitude = 500;
    public void OnCollisionEnter(Collision other)
    {
        // how much the character should be knocked back
       
        // calculate force vector
        var force = other.transform.position - transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        other.rigidbody.AddForce(force * magnitude);
    }
}
