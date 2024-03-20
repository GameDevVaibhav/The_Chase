using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBikeCollision : MonoBehaviour
{
    public GameObject impactPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool bikeCollision = collision.gameObject.CompareTag("PoliceBike");
        bool carCollision = collision.gameObject.CompareTag("PoliceCar");
        bool swatCollision = collision.gameObject.CompareTag("SwatCar");
        bool baricetCollision = collision.gameObject.CompareTag("Baricet");
        bool playerCollision = collision.gameObject.CompareTag("PlayerCar");

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        HandleVibration handleVibration = FindObjectOfType<HandleVibration>();
        CarDestroyCounter bikeDestroyCounter = FindObjectOfType<CarDestroyCounter>();
        if (bikeCollision)
        {

            
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
                
            }
            
            Destroy(gameObject);
            bikeDestroyCounter.BikeDestroyed();
            InstantiateImpactPrefab(collision.contacts[0].point);

            if (scoreManager != null)
            {
                scoreManager.IncreaseBountyOnDestroy(10);
            }
        }
        if (carCollision || swatCollision || baricetCollision||playerCollision)
        {
            
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
            }
            Destroy(gameObject);
            bikeDestroyCounter.BikeDestroyed();
            scoreManager.IncreaseBountyOnDestroy(10);
            InstantiateImpactPrefab(collision.contacts[0].point);
        }
    }

    private void InstantiateImpactPrefab(Vector2 position)
    {
        
        if (impactPrefab != null)
        {
            Instantiate(impactPrefab, position, Quaternion.identity);
        }
    }
}
