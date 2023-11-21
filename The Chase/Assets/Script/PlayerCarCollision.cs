using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCollision : MonoBehaviour
{
    public GameOverUI gameOverUI;
    public float playerHealth = 10f;
    private float lastCollisionTime = 0f;
    private float timeBetweenCollisions = 4f; // Set the time limit for resetting health here.
    private float swatCarDamageInterval = 1.0f; // Time interval to reduce health if a SwatCar is in the scene.
    private float lastSwatCarDamageTime = 0f;
    private float swatCarDamage;
    public HandleVibration handleVibration;

    public bool canMove = true;
    public bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove) // Only process collisions if the car can move.
        {
            if (collision.gameObject.CompareTag("PoliceCar"))
            {
                playerHealth -= 4f; // Reduce health by 5 when a car collides.
                handleVibration.TriggerShortVibration();
            }
            else if (collision.gameObject.CompareTag("PoliceBike"))
            {
                playerHealth -= 3f; // Reduce health by 3 when a bike collides.
                handleVibration.TriggerShortVibration();
            }
            else if (collision.gameObject.CompareTag("Baricet"))
            {
                playerHealth -= 5f; // Reduce health by 7 when a barrier collides.
                handleVibration.TriggerShortVibration();
            }

            lastCollisionTime = Time.time; // Update the last collision time.
        }

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
            HandleVibration handleVibration = GetComponent<HandleVibration>();
            if (handleVibration != null)
            {
                handleVibration.TriggerLongVibration();
            }

            canMove= false;
            isGameOver=true;
            gameOverUI.ShowGameOverUI();
        }
    }

    private bool SwatCarIsInScene()
    {
        GameObject[] swatCars = GameObject.FindGameObjectsWithTag("SwatCar");
        if (swatCars.Length >= 2)
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
            

          
        }
    }

   
}
