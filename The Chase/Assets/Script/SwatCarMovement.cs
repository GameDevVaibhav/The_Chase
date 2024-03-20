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
    public Transform target;
    public Vector3 offset; 

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 desiredPosition = target.position + target.right * offset.x;

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.fixedDeltaTime*0.3f);

        
        transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, moveSpeed * Time.fixedDeltaTime);

        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
        myRigidBody.angularVelocity = -input * steer * 10f;
    }
}
