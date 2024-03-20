using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moving car in main menu
public class CarMainMenu : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myRigidBody;
    float moveSpeed = 5f;

   
    void Update()
    {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
    }
}
