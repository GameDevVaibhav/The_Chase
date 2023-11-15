using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMainMenu : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myRigidBody;
    float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
    }
}
