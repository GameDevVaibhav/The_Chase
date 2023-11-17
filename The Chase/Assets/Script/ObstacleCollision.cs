using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject impactPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SwatCar"))
        {
            HandleVibration handleVibration = GetComponent<HandleVibration>();
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
            }
            Destroy(gameObject);
            InstantiateImpactPrefab(collision.contacts[0].point);
        }
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
            HandleVibration handleVibration = GetComponent<HandleVibration>();
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
        // Instantiate the impact prefab at the specified position.
        if (impactPrefab != null)
        {
            Instantiate(impactPrefab, position, Quaternion.identity);
        }
    }
}
