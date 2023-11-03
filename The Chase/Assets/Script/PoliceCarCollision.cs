using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarCollision : MonoBehaviour
{
    private int collisionCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        bool bikeCollision = collision.gameObject.CompareTag("PoliceBike");
        bool carCollision = collision.gameObject.CompareTag("PoliceCar");
        bool swatCollision = collision.gameObject.CompareTag("SwatCar");
        bool baricetCollision = collision.gameObject.CompareTag("Baricet");
        bool playerCollision = collision.gameObject.CompareTag("PlayerCar");


        if (swatCollision || baricetCollision || playerCollision || carCollision)
        {
            Destroy(gameObject);
            scoreManager.IncreaseBountyOnDestroy(50);
        }

        if (bikeCollision)
        {
            collisionCount++; // Increment the collision count when colliding with a police bike.

            // Check if the collision count reaches 3, and destroy the police car if it does.
            if (collisionCount >= 3)
            {
                Destroy(gameObject);
                
                if (scoreManager != null)
                {
                    scoreManager.IncreaseBountyOnDestroy(25); // Adjust the bounty amount as needed.
                }

                collisionCount = 0;
            }
        }
        
        
    }


}
