using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // Reference to the pickup prefab.
    public GameObject cashPickupPrefab; // Reference to the CashPickup prefab.
    public Transform playerCarTransform; // Reference to the player car's transform.
    public float yOffset = 5.0f; // Vertical offset for spawning (adjust as needed).
    public float speedSpawnInterval = 10.0f; // Time interval between spawning pickups.
    public float cashSpawnInterval = 5.0f; // Time interval between spawning CashPickups.
    public Transform[] speedBoostSpawnPoints; // Array of spawn points for speed boost pickups.
    public Transform[] cashSpawnPoints; // Array of spawn points for cash pickups.
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

        if (timeSinceLastSpawn >= speedSpawnInterval)
        {
            SpawnSpeedBoostPickup();
            timeSinceLastSpawn = 0;
        }

        if (timeSinceLastCashSpawn >= cashSpawnInterval)
        {
            SpawnCashPickup();
            timeSinceLastCashSpawn = 0;
        }
    }

    private void SpawnSpeedBoostPickup()
    {
        if (speedBoostSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No speed boost spawn points assigned to the PickupSpawner.");
            return;
        }

        // Select a random spawn point from the array.
        int randomIndex = Random.Range(0, speedBoostSpawnPoints.Length);
        Transform spawnPoint = speedBoostSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);

        // Use the selected spawn point to determine the position of the pickup.
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomX, camHeight + yOffset, 0);

        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnCashPickup()
    {
        if (cashSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No cash pickup spawn points assigned to the PickupSpawner.");
            return;
        }

        // Select a random spawn point from the array.
        int randomIndex = Random.Range(0, cashSpawnPoints.Length);
        Transform spawnPoint = cashSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);

        // Use the selected spawn point to determine the position of the cash pickup.
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomX, camHeight + yOffset, 0);

        Instantiate(cashPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
