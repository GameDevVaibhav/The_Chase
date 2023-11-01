using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatSpawner : MonoBehaviour
{
    public GameObject swatCarPrefab; // Reference to the SWAT car prefab.
    public Transform playerCarTransform; // Reference to the player car's transform.
    public Transform leftSpawnPoint; // Reference to the left spawn point.
    public Transform rightSpawnPoint; // Reference to the right spawn point.
    public Vector3[] swatCarOffsets; // Offsets for SWAT cars (set in the Inspector).

    private GameObject[] spawnedCars; // Array to keep track of spawned SWAT cars

    private void Start()
    {
        spawnedCars = new GameObject[2]; // Initialize the array to hold 2 SWAT cars
        SpawnSwatCar(0, leftSpawnPoint, swatCarOffsets[0]);
        SpawnSwatCar(1, rightSpawnPoint, swatCarOffsets[1]);
    }

    private void SpawnSwatCar(int index, Transform spawnPoint, Vector3 offset)
    {
        spawnedCars[index] = Instantiate(swatCarPrefab, spawnPoint.position, Quaternion.identity);

        // Assign the player car as the target to the SWAT car.
        SwatCarMovement swatCarMovement = spawnedCars[index].GetComponent<SwatCarMovement>();
        if (swatCarMovement != null)
        {
            swatCarMovement.target = playerCarTransform;
            swatCarMovement.offset = offset;
        }
    }
}
