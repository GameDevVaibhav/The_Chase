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
            speedBoostPickup();
            timeSinceLastSpawn = 0;
        }

        if (timeSinceLastCashSpawn >= cashSpawnInterval)
        {
            SpawnCashPickup();
            timeSinceLastCashSpawn = 0;
        }
    }


    private System.Random speedBoostRandomGenerator = new System.Random();
    private System.Random cashRandomGenerator = new System.Random();

 

    private Vector3 GetRandomSpawnPosition(System.Random randomGenerator)
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = (float)(randomGenerator.NextDouble() * (2 * camWidth) - camWidth);
        Vector3 spawnPosition = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);
        return spawnPosition;
    }

 

    private void speedBoostPickup()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition(speedBoostRandomGenerator);
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnCashPickup()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition(cashRandomGenerator);
        Instantiate(cashPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
