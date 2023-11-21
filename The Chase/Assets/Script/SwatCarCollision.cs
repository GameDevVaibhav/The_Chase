using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatCarCollision : MonoBehaviour
{
    public GameObject impactPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleVibration handleVibration = FindObjectOfType<HandleVibration>();
        if (collision.gameObject.CompareTag("Baricet"))
        {
           
            if (handleVibration != null)
            {
                handleVibration.TriggerShortVibration();
            }
            Destroy(gameObject);
            InstantiateImpactPrefab(collision.contacts[0].point);
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseBountyOnDestroy(30);
                // Adjust the bounty amount as needed.
            }
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
