using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject barrierPrefab; // Reference to the barrier prefab.
    public float spawnInterval = 4.0f; // Time interval between spawning.
    public float yOffset = 5.0f; // Vertical offset for spawning (adjust as needed).
    public Transform playerCarTransform; // Reference to the player car's transform.

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
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnObstacles()
    {
        // Get the camera's size and aspect ratio
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Calculate the X position within the camera's view
        float randomX = Random.Range(-camWidth, camWidth);

        // Calculate the spawn position based on player car's position and the calculated X position
        Vector3 spawnPosition1 = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);
        Vector3 spawnPosition2 = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);

        GameObject barrier1 = Instantiate(barrierPrefab, spawnPosition1, Quaternion.identity);
        //GameObject barrier2 = Instantiate(barrierPrefab, spawnPosition2, Quaternion.identity);

       

       
        Destroy(barrier1, 10.0f);
        //Destroy(barrier2, 10.0f);
    }
}
