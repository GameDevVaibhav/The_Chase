using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustingArea : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private int policeCarCount = 0;

    private void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject.
        spriteRenderer = GetComponent < SpriteRenderer>();
        // Initially, the sprite should be invisible (disabled).
        spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PoliceBike") || other.CompareTag("PoliceCar"))
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
