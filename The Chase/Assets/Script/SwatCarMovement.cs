using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatCarMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 20f;
    [SerializeField]
    float steer = 10f;
    float input;

    public GameObject carToFollow; // Reference to Car1
    public Vector3 offset; // Offset to the left of Car1
    public float followPositionSpeed = 5.0f; // Speed at which Car2 follows Car1's position
    public float followRotationSpeed = 5.0f; // Speed at which Car2 follows Car1's rotation

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent < Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the desired position of Car2 with an offset to the left
        Vector3 desiredPosition = carToFollow.transform.position - carToFollow.transform.right * offset.x;

        // Gradually move Car2 towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followPositionSpeed * Time.fixedDeltaTime);

        // Gradually rotate Car2 towards the desired rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, carToFollow.transform.rotation, followRotationSpeed * Time.fixedDeltaTime);

        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
        myRigidBody.angularVelocity = -input * steer * 10f;
    }
}
