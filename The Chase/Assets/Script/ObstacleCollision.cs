using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when obstacle collision occurs impact vfx is instantiated and obstacle is destroyed;
public class ObstacleCollision : MonoBehaviour
{
    public GameObject impactPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleVibration handleVibration = FindObjectOfType<HandleVibration>();
        if (collision.gameObject.CompareTag("SwatCar"))
        {
           
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
                Debug.Log("Swat car vibrate");
            }
            Destroy(gameObject);
            InstantiateImpactPrefab(collision.contacts[0].point);
        }
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
            
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
            }
            Destroy(gameObject);
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
