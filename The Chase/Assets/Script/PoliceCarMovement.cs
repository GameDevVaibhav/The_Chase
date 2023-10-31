using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 20f;
    [SerializeField]
    float steer = 10f;
    [SerializeField]
    float offset;
    public Transform target;
    float input;


    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
       // input = Input.GetAxis("Horizontal");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
        Vector2 direction = (target.position - transform.position).normalized+ new Vector3(offset,0f,0f);
        float rotationSteer=Vector3.Cross(transform.up,direction).z;
        myRigidBody.angularVelocity = rotationSteer * steer * 10f;
    }
}
