using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public AudioSource audioSource;
    public AudioSource audioCash;

    public GameObject impactPrefab;
    public GameObject impactPrefabPoint;

    private PlayerCarCollision playerCarCollision;

    public SpriteRenderer carSpriteRenderer;

    public List<Sprite> carSprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
        scoreManager = FindObjectOfType<ScoreManager>();

        playerCarCollision = GetComponent<PlayerCarCollision>();

        // Retrieve the selected car index from PlayerPrefs
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);

        carSelect(selectedCarIndex);
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
            InstantiateImpactPrefab(impactPrefabPoint.transform.position);
            Destroy(other.gameObject);
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
        if (other.CompareTag("Cash"))
        {
            scoreManager.IncreaseCash(10);
            Destroy(other.gameObject);
            if (audioCash != null)
            {
                audioCash.Play();
            }
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

    private void InstantiateImpactPrefab(Vector2 position)
    {
        // Instantiate the impact prefab at the specified position.
        if (impactPrefab != null)
        {
            Instantiate(impactPrefab, position, Quaternion.identity);
        }
    }

    private void carSelect(int selectedCarIndex)
    {
        if (selectedCarIndex >= 0 && selectedCarIndex < carSprites.Count)
        {
            carSpriteRenderer.sprite = carSprites[selectedCarIndex];
        }
        else
        {
            Debug.LogWarning("Selected car index not found. Using default sprite.");
            // Example: carSpriteRenderer.sprite = defaultSprite;
        }
    }
}
