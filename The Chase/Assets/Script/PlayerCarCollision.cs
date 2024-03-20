using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reduce player health when collision takes place. If there are swat cars in the scene reduce player health. If health<0 game over.
public class PlayerCarCollision : MonoBehaviour
{
    public GameOverUI gameOverUI;
    public float playerHealth = 10f;
    private float lastCollisionTime = 0f;
    private float timeBetweenCollisions = 4f; 
    private float swatCarDamageInterval = 1.0f; 
    private float lastSwatCarDamageTime = 0f;
    private float swatCarDamage;
    public HandleVibration handleVibration;

    public bool canMove = true;
    public bool isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove) 
        {
            if (collision.gameObject.CompareTag("PoliceCar"))
            {
                playerHealth -= 4f; 
                handleVibration.TriggerShortVibration();
            }
            else if (collision.gameObject.CompareTag("PoliceBike"))
            {
                playerHealth -= 3f; 
                handleVibration.TriggerShortVibration();
            }
            else if (collision.gameObject.CompareTag("Baricet"))
            {
                playerHealth -= 5f; 
                handleVibration.TriggerShortVibration();
            }

            lastCollisionTime = Time.time; 
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
            
            playerHealth = 10;
        }

        
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
            playerHealth -= swatCarDamage; 
            lastSwatCarDamageTime = Time.time; 
            

          
        }
    }

   
}
