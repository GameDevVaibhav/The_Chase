using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustingArea : MonoBehaviour
{
    public GameOverUI gameOverUI;

    private SpriteRenderer spriteRenderer;
    private int policeCarCount = 0;
    public float activeTimer = 0f;
    private bool gameIsOver = false;

    private void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject.
        spriteRenderer = GetComponent < SpriteRenderer>();
        // Initially, the sprite should be invisible (disabled).
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        // Check if the sprite renderer is active.
        if (spriteRenderer.enabled)
        {
            activeTimer += Time.deltaTime;

            // If the timer exceeds 5 seconds and the game is not over, trigger game over.
            if (activeTimer >= 4f && !gameIsOver)
            {
                Debug.Log("Busted");
                gameOverUI.ShowGameOverUI();
                gameIsOver = true;
                
            }
        }
        else
        {
            // Reset the timer when the sprite renderer is not active.
            activeTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PoliceBike")||other.CompareTag("PoliceCar"))
        {
            Debug.Log("Police Car entered");
            policeCarCount++;
            // Enable the sprite when at least one police car enters.
            if (policeCarCount > 0)
            {
                spriteRenderer.enabled = true;
                // You can also change the sprite's color to red if desired.
                // spriteRenderer.color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PoliceBike") || other.CompareTag("PoliceCar"))
        {
            Debug.Log("Police Car Exit");
            policeCarCount--;
            // Disable the sprite when there are no police cars in the area.
            if (policeCarCount == 0)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
    
}
