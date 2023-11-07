using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCollision : MonoBehaviour
{
    public float playerHealth = 10f;
    private float lastCollisionTime = 0f;
    private float timeBetweenCollisions = 4f; // Set the time limit for resetting health here.
    private float swatCarDamageInterval = 1.0f; // Time interval to reduce health if a SwatCar is in the scene.
    private float lastSwatCarDamageTime = 0f;
    private float swatCarDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            playerHealth -= 4f; // Reduce health by 5 when a car collides.
        }
        else if (collision.gameObject.CompareTag("PoliceBike"))
        {
            playerHealth -= 3f; // Reduce health by 3 when a bike collides.
        }
        else if (collision.gameObject.CompareTag("Baricet"))
        {
            playerHealth -= 5f; // Reduce health by 7 when a barrier collides.
        }

        lastCollisionTime = Time.time; // Update the last collision time.
        Debug.Log("Player Health: " + playerHealth);
        Debug.Log("Last Collision Time: " + lastCollisionTime);
    }

    private void Update()
    {
        if (SwatCarIsInScene())
        {
            ReduceHealthForSwatCar();
        }
        else if (Time.time - lastCollisionTime >= timeBetweenCollisions)
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

    private bool SwatCarIsInScene()
    {
        GameObject[] swatCars = GameObject.FindGameObjectsWithTag("SwatCar");
        if (swatCars.Length == 2)
        {
            swatCarDamage = 0.15f * 2;
        }
        else if (swatCars.Length == 1)
        {
            swatCarDamage = 0.15f;
        }
        else
        {
            swatCarDamage= 0f;
        }

        return swatCarDamage> 0;
    }

    private void ReduceHealthForSwatCar()
    {
        if (Time.time - lastSwatCarDamageTime >= swatCarDamageInterval)
        {
            playerHealth -= swatCarDamage; // Reduce health by 0.5 every second when a SwatCar is in the scene.
            lastSwatCarDamageTime = Time.time; // Update the last time health was reduced.
            Debug.Log("Player Health Reduced by SwatCar: " + playerHealth);
        }
    }
}
