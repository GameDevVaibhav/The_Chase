using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public GameObject policeCarPrefab; // Reference to the police car prefab.
    public Transform playerCarTransform; // Reference to the player car's transform.
    public float spawnInterval = 3.0f; // Time interval between spawns.
    public float spawnXOffset = 10.0f; // Offset from the camera's view on the x-axis.

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
            SpawnCar();
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnCar()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject policeCar = Instantiate(policeCarPrefab, spawnPosition, Quaternion.identity);

        // Assign the player car as the target to the police car.
        PoliceCarMovement policeCarMovement = policeCar.GetComponent<PoliceCarMovement>();
        if (policeCarMovement != null)
        {
            policeCarMovement.target = playerCarTransform;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float randomX = Random.Range(-camWidth + spawnXOffset, camWidth - spawnXOffset);
        float spawnY = camHeight + 2; // Adjust the spawn height as needed.

        return new Vector3(randomX, spawnY, 0);
    }
}
