using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // The player character
    public Rigidbody player;

    // The enemy character
    public Rigidbody self;

    // The speed at which the enemy moves
    public float speed = 3;

    // The radius at which the enemy detects the player character
    public float radius = 5;

    // The amount of times the enemy needs to be hit to get destroyed
    public int health = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Locates the player from the enemy
        Vector3 playerLoc = player.position - gameObject.transform.position;
        playerLoc.y = 0;

        // If the player is within the radius...
        if (playerLoc.magnitude < radius)
        {
            // Face the player
            Quaternion direction;
            direction = Quaternion.LookRotation(playerLoc);
            gameObject.transform.rotation = direction;

            // Move forward
            Vector3 vel = gameObject.transform.forward * speed;
            self.velocity = vel;
        }
        
    }

    // Lowers health of and/or kills the enemy when hit by the Sword
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            health--;
        }
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
