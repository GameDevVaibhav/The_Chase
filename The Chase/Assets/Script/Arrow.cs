using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 initialTouchPosition;
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
        if (Input.touchCount > 0) // Check if there are any touches
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
                initialObjectPosition = transform.position;
                isDragging = true;
            }

            if (isDragging)
            {
                Vector3 currentTouchPosition = touch.position;
                Vector3 touchMovement = (currentTouchPosition - initialTouchPosition) * sensitivity;
                initialTouchPosition = currentTouchPosition;

                Vector3 newPosition = transform.position + new Vector3(touchMovement.x, touchMovement.y, 0f);

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

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
