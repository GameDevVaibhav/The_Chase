using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarCollision : MonoBehaviour
{
    private int collisionCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PoliceBike"))
        {
            collisionCount++; // Increment the collision count when colliding with a police bike.

            // Check if the collision count reaches 3, and destroy the police car if it does.
            if (collisionCount >= 3)
            {
                Destroy(gameObject);
                
                collisionCount = 0;
            }
        }
    }


}
