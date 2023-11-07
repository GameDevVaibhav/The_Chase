using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject barrierPrefab; // Reference to the barrier prefab.
    public GameObject swatCarPrefab; // Reference to the SWAT car prefab.
    public float spawnInterval = 4.0f; // Time interval between spawning.
    public float yOffset = 5.0f; // Vertical offset for spawning (adjust as needed).
    public Transform playerCarTransform; // Reference to the player car's transform.
    public bool spawnObstacle=true;

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
            Debug.Log("Baricet Spawn");
            
            //CheckForSwatCars();
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnObstacles()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float randomX = Random.Range(-camWidth, camWidth);
        Vector3 spawnPosition1 = playerCarTransform.position + new Vector3(randomX, camHeight + yOffset, 0);
        GameObject barrier1 = Instantiate(barrierPrefab, spawnPosition1, Quaternion.identity);
        Destroy(barrier1, 10.0f);
    }

    //private void CheckForSwatCars()
    //{
    //    GameObject[] swatCars = GameObject.FindGameObjectsWithTag("SwatCar");

    //    if (swatCars.Length > 0)
    //    {
    //       spawnObstacle= true;
    //    }
    //    else
    //    {
    //        spawnObstacle= false;
    //    }
    //}
}
