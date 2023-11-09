using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject barrierPrefab; // Reference to the barrier prefab.
    public Transform[] obstacleSpawnPoints; // Array of spawn points for obstacles.
    public float spawnInterval = 4.0f; // Time interval between spawning.
    public float yOffset = 5.0f; // Vertical offset for spawning (adjust as needed).
    public bool spawnObstacle = true;

    private Camera mainCamera;
    private float timeSinceLastSpawn = 0;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacles();
            Debug.Log("Barrier Spawn");

            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnObstacles()
    {
        if (obstacleSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No obstacle spawn points assigned to the ObstacleSpawner.");
            return;
        }

        // Select a random spawn point from the array.
        int randomIndex = Random.Range(0, obstacleSpawnPoints.Length);
        Transform spawnPoint = obstacleSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Use the selected spawn point to determine the position of the obstacle.
        float randomX = Random.Range(-camWidth, camWidth);
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomX, camHeight + yOffset, 0);

        GameObject barrier = Instantiate(barrierPrefab, spawnPosition, Quaternion.identity);
        Destroy(barrier, 10.0f);
    }
}
