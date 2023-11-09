using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public GameObject policeCarPrefab; // Reference to the police car prefab.
    public Transform playerCarTransform; // Reference to the player car's transform.
    public Transform[] spawnPoints; // Array of spawn points for police cars.
    public float spawnInterval = 3.0f; // Time interval between spawns.

    private float timeSinceLastSpawn = 0;

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
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to the PoliceSpawner.");
            return;
        }

        // Select a random spawn point from the array.
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn the police car at the selected spawn point.
        GameObject policeCar = Instantiate(policeCarPrefab, spawnPoint.position, Quaternion.identity);

        // Assign the player car as the target to the police car.
        PoliceCarMovement policeCarMovement = policeCar.GetComponent<PoliceCarMovement>();
        if (policeCarMovement != null)
        {
            policeCarMovement.target = playerCarTransform;
        }
    }


}
