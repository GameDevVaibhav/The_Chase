using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            Destroy(gameObject); // Destroy the pickup upon collection by the player car.
        }
    }
}
