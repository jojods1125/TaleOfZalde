using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sideForce = 200f;
    public float upForce = 200f;
    public float maxVelocity = 1000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        ClampVelocity();
        
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-forwardForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, forwardForce * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, -forwardForce * Time.deltaTime, 0);
        }

    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);
        float z = Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity);

        rb.velocity = new Vector3(x, y, z);
    }


}