using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCollision : MonoBehaviour
{
    public int playerHealth = 10;
    private float lastCollisionTime = 0f;
    private float timeBetweenCollisions = 4f; // Set the time limit for resetting health here.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            playerHealth -= 5; // Reduce health by 5 when a car collides.
            
        }
        else if (collision.gameObject.CompareTag("PoliceBike"))
        {
            playerHealth -= 3; // Reduce health by 3 when a bike collides.
        }
        else if (collision.gameObject.CompareTag("Baricet"))
        {
            playerHealth -= 7; // Reduce health by 7 when a barrier collides.
        }
        

        lastCollisionTime = Time.time; // Update the last collision time.
        Debug.Log(playerHealth);
        Debug.Log(lastCollisionTime);
    }

    private void Update()
    {
        if (Time.time - lastCollisionTime >= timeBetweenCollisions)
        {
            // If no collision within the specified time, reset player health.
            playerHealth = 10;
        }

        // Check for game over or other conditions based on player health.
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
