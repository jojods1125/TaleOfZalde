using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zalde : MonoBehaviour
{
    // The character object
    public Rigidbody player;

    // The speed the character moves at
    public float speed = 5;

    // The jump height of the character
    public float jumpHeight = 5;

    // The sword object
    public GameObject sword;

    // The direction the character is facing
    private Quaternion direction;

    // Power enum; used by ActivatePower object and activePower() to turn on Powers
    public enum Power
    {
        Jump = 0,
        Sword = 1,
        Run = 2
    }

    // Power booleans; true means that it can be used
    private bool powerJump = false;
    private bool powerSword = false;
    private bool powerRun = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Makes the player move based on the current input axis values
        player.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, player.velocity.y, Input.GetAxis("Vertical") * speed);

        // Version of velocity used for rotation of the character
        Vector3 vel = new Vector3(player.velocity.x, 0, player.velocity.z);

        // If the player is moving, set the rotation
        if (vel != new Vector3(0, 0, 0))
        {
            direction = Quaternion.LookRotation(vel);
            gameObject.transform.rotation = direction;
        }

        // Use Jump if the player presses space and has Jump
        if (Input.GetKey(KeyCode.Space) && powerJump)
        {
            if (GroundCheck())
            {
                player.velocity = new Vector3(player.velocity.x, jumpHeight, player.velocity.z);
            }
        }

        // Use Sword if the player presses left click and has Sword
        if (Input.GetKey(KeyCode.Mouse0) && powerSword)
        {
            sword.GetComponent<MeshRenderer>().enabled = true;
            sword.GetComponent<BoxCollider>().enabled = true;
        } else
        {
            sword.GetComponent<MeshRenderer>().enabled = false;
            sword.GetComponent<BoxCollider>().enabled = false;
        }

        // Use Run if the player presses right click and has Run
        /**
         * 
         * CREATE THIS ABILITY HERE
         * 
         */

    }

    // Activates a Power; used by the ActivatePower object
    public void activePower(Power power)
    {
        if (power == Power.Jump)
        {
            powerJump = true;
        }
        if (power == Power.Sword)
        {
            powerSword = true;
        }
        if (power == Power.Run)
        {
            powerRun = true;
        }
    }

    // Checks if there is ground beneath the character
    private bool GroundCheck()
    {
        // Distance of 1.01 below the character; change this based on character size
        float distance = 1.01f;
        
        // Direction of the raycast; -1 y goes below the character vertically
        Vector3 dir = new Vector3(0, -1, 0);

        // Raycasts below the character and returns true if it hits something
        if (Physics.Raycast(player.position, dir, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
