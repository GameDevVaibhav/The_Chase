using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // Reference to the pickup prefab.
    public GameObject cashPickupPrefab; // Reference to the CashPickup prefab.
    public Transform playerCarTransform; // Reference to the player car's transform.
    public float yOffset = 5.0f; // Vertical offset for spawning (adjust as needed).
    public float spawnInterval = 10.0f; // Time interval between spawning pickups.
    public float cashSpawnInterval = 5.0f; // Time interval between spawning CashPickups.
    private float timeSinceLastSpawn = 0;
    private float timeSinceLastCashSpawn = 0;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        timeSinceLastCashSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPickup();
            timeSinceLastSpawn = 0;
        }

        if (timeSinceLastCashSpawn >= cashSpawnInterval)
        {
            SpawnCashPickup();
            timeSinceLastCashSpawn = 0;
        }
    }

    private void SpawnPickup()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);
        Vector3 spawnPosition = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnCashPickup()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);
        Vector3 spawnPosition = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);
        Instantiate(cashPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
