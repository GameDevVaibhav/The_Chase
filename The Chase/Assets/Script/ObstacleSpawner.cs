using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Random spawn point is selected and obstacle is spawned at that position.
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject barrierPrefab; 
    public Transform[] obstacleSpawnPoints; 
    public float spawnInterval = 4.0f; 
    public float yOffset = 5.0f; 
    public bool spawnObstacle = true;

    private Camera mainCamera;
    private float timeSinceLastSpawn = 0;
    private PlayerCarCollision playerCarCollision;

    private void Start()
    {
        mainCamera = Camera.main;
        playerCarCollision = FindObjectOfType<PlayerCarCollision>();
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
        if (obstacleSpawnPoints.Length == 0)
        {
           
            return;
        }
        if (playerCarCollision.isGameOver)
        {
            return;
        }

        
        int randomIndex = Random.Range(0, obstacleSpawnPoints.Length);
        Transform spawnPoint = obstacleSpawnPoints[randomIndex];

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        
        float randomX = Random.Range(-camWidth, camWidth);
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomX, camHeight + yOffset, 0);

        GameObject barrier = Instantiate(barrierPrefab, spawnPosition, Quaternion.identity);
        Destroy(barrier, 10.0f);
    }
}
