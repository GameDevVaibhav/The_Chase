using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Random spawn points is selected and spawns the cash/speedboost. 
public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; 
    public GameObject cashPickupPrefab; 
    public Transform playerCarTransform; 
    public float yOffset = 5.0f; 
    public float speedSpawnInterval = 10.0f; 
    public float cashSpawnInterval = 5.0f; 
    public Transform[] speedBoostSpawnPoints; 
    public Transform[] cashSpawnPoints; 
    private float timeSinceLastSpawn = 0;
    private float timeSinceLastCashSpawn = 0;

    private Camera mainCamera;
    private PlayerCarCollision playerCarCollision;

    private void Start()
    {
        mainCamera = Camera.main;
        playerCarCollision = FindObjectOfType<PlayerCarCollision>();
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
        if (playerCarCollision.isGameOver)
        {
            return;
        }

       
        int randomIndex = Random.Range(0, speedBoostSpawnPoints.Length);
        Transform spawnPoint = speedBoostSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);

        
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
        if (playerCarCollision.isGameOver)
        {
            return;
        }

        
        int randomIndex = Random.Range(0, cashSpawnPoints.Length);
        Transform spawnPoint = cashSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);

        
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomX, camHeight + yOffset, 0);

        Instantiate(cashPickupPrefab, spawnPosition, Quaternion.identity);
    }
}
