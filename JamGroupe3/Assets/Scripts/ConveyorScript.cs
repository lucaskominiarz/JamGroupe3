using System;
using System.Collections;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    
    private void Awake()
    {
        direction = direction.normalized;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb;
        try
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        rb.linearVelocity += direction * speed;
    }
}
