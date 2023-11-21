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
    [SerializeField]
    private Transform target;

    Rigidbody2D myRigidBody;
    ScoreManager scoreManager;

    private PlayerCarCollision playerCarCollision;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent < Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
        scoreManager=FindObjectOfType<ScoreManager>();

        playerCarCollision = GetComponent<PlayerCarCollision>();
    }

    void Update()
    {
       input = Input.GetAxis("Horizontal");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the direction from the player to the target
        Vector3 directionToTarget = target.position - transform.position;

        // Calculate the angle to rotate the player to face the target
        float angleToTarget = Mathf.Atan2(directionToTarget.x, directionToTarget.y) * Mathf.Rad2Deg;

        // Rotate the player to face the target
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -angleToTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, steer * Time.fixedDeltaTime);

        // Move the player perpendicular to the target
        if (playerCarCollision.canMove)
        {
            myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime * 10f;
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBooster"))
        {
            ApplySpeedBoost();
            Destroy(other.gameObject); 
        }
        if (other.CompareTag("Cash"))
        {
            scoreManager.IncreaseCash(10);
            Destroy(other.gameObject);
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
