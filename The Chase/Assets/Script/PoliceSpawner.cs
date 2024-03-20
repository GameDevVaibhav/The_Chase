using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public GameObject policeCarPrefab; 
    public Transform playerCarTransform; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 3.0f; 

    private float timeSinceLastSpawn = 0;

    private PlayerCarCollision playerCarCollision;

    private void Start()
    {
        playerCarCollision = FindObjectOfType<PlayerCarCollision>();
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
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to the PoliceSpawner.");
            return;
        }
        if (playerCarCollision.isGameOver)
        {
            return;
        }

        
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        
        GameObject policeCar = Instantiate(policeCarPrefab, spawnPoint.position, Quaternion.identity);

       
        PoliceCarMovement policeCarMovement = policeCar.GetComponent<PoliceCarMovement>();
        if (policeCarMovement != null)
        {
            policeCarMovement.target = playerCarTransform;
        }
    }


}
