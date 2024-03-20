using UnityEngine;

//Arrow guides the player car. Car rotate towards the arrow. Arrow is clamped inside a circular area.
public class Arrow : MonoBehaviour
{
    private Vector3 initialTouchPosition;
    private Vector3 initialObjectPosition;
    private bool isDragging = false;
    [SerializeField]
    private float sensitivity = 0.01f;
    [SerializeField]
    private float maxDistanceFromCenter = 1.0f; 

    
    public Transform parentObject;

    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0); 

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

                
                float distanceFromCenter = Vector3.Distance(parentObject.position, newPosition);

               
                if (distanceFromCenter <= maxDistanceFromCenter)
                {
                    transform.position = newPosition;
                }
                else
                {
                    
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
