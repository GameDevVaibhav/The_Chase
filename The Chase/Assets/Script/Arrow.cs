using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 initialMousePosition;
    private Vector3 initialObjectPosition;
    private bool isDragging = false;
    [SerializeField]
    private float sensitivity = 0.01f;
    [SerializeField]
    private float maxDistanceFromCenter = 1.0f; // Maximum distance from the parent object's center

    // Reference to the parent object
    public Transform parentObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
            initialObjectPosition = transform.position;
            isDragging = true;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseMovement = (currentMousePosition - initialMousePosition) * sensitivity;
            initialMousePosition = currentMousePosition;

            Vector3 newPosition = transform.position + new Vector3(mouseMovement.x, mouseMovement.y, 0f);

            // Calculate the distance from the parent object's center
            float distanceFromCenter = Vector3.Distance(parentObject.position, newPosition);

            // Ensure the object stays within the circular boundary
            if (distanceFromCenter <= maxDistanceFromCenter)
            {
                transform.position = newPosition;
            }
            else
            {
                // If the object goes beyond the boundary, clamp it back
                Vector3 directionFromCenter = (newPosition - parentObject.position).normalized;
                transform.position = parentObject.position + directionFromCenter * maxDistanceFromCenter;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
