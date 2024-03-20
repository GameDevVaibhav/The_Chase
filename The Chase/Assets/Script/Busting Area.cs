using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If police car enters the busting area and stays more then 4sec , player is busted and game is over.
public class BustingArea : MonoBehaviour
{
    public GameOverUI gameOverUI;

    private SpriteRenderer spriteRenderer;
    private int policeCarCount = 0;
    public float activeTimer = 0f;
    
    private PlayerCarCollision playerCarCollision;

    private void Start()
    {
        playerCarCollision = FindObjectOfType<PlayerCarCollision>();
        
        spriteRenderer = GetComponent < SpriteRenderer>();
       
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        
        if (spriteRenderer.enabled)
        {
            activeTimer += Time.deltaTime;

            
            if (activeTimer >= 4f && !playerCarCollision.isGameOver)
            {
                Debug.Log("Busted");
                gameOverUI.ShowGameOverUI();
                playerCarCollision.isGameOver = true;
                playerCarCollision.canMove= false;
                
            }
        }
        else
        {
            
            activeTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PoliceBike")||other.CompareTag("PoliceCar"))
        {
            
            policeCarCount++;
           
            if (policeCarCount > 0)
            {
                spriteRenderer.enabled = true;
                
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PoliceBike") || other.CompareTag("PoliceCar"))
        {
            
            policeCarCount--;
            
            if (policeCarCount == 0)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
    
}
