using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 20f;
    [SerializeField]
    float steer = 10f;
    float input;
    bool isSpeedBoosted = false;
    [SerializeField]
    float speedBoostDuration = 3.0f;
    float originalMoveSpeed;

    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent < Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
        myRigidBody.angularVelocity = -input * steer * 10f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBooster"))
        {
            ApplySpeedBoost();
            Destroy(other.gameObject); // Destroy the pickup.
        }
    }

    private void ApplySpeedBoost()
    {
        if (!isSpeedBoosted)
        {
            isSpeedBoosted = true;
            StartCoroutine(SpeedBoostEffect());
        }
    }

    IEnumerator SpeedBoostEffect()
    {
        moveSpeed += 2.0f; // Increase the speed when the pickup is collected.

        yield return new WaitForSeconds(speedBoostDuration);

        moveSpeed = originalMoveSpeed; // Return to the original speed.

        isSpeedBoosted = false;
    }

}
