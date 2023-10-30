using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed=20f;
    [SerializeField]
    float steer = 10f;
    float input;
    

    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody= GetComponent<Rigidbody2D>();   
       
    }
     void Update()
    {
        input = Input.GetAxis("Horizontal");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.velocity = transform.up * moveSpeed*Time.fixedDeltaTime*10f;
        myRigidBody.angularVelocity = -input * steer * 10f;
    }
}
