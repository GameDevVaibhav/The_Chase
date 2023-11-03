using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBikeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool bikeCollision = collision.gameObject.CompareTag("PoliceBike");
        bool carCollision = collision.gameObject.CompareTag("PoliceCar");
        bool swatCollision = collision.gameObject.CompareTag("SwatCar");
        bool baricetCollision = collision.gameObject.CompareTag("Baricet");
        bool playerCollision = collision.gameObject.CompareTag("PlayerCar");

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (bikeCollision)
        {
            Destroy(gameObject);
            
            if (scoreManager != null)
            {
                scoreManager.IncreaseBountyOnDestroy(10); // Adjust the bounty amount as needed.
            }
        }
        if (carCollision || swatCollision || baricetCollision||playerCollision)
        {
            Destroy(gameObject);
            scoreManager.IncreaseBountyOnDestroy(10);
        }
    }
}
