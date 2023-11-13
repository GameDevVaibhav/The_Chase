using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackGroundSpawner : MonoBehaviour
{
    public GameObject backgroundPrefab;
    private Transform playerTransform;
    private Vector2 lastPlayerPosition;

    private void Start()
    {
        playerTransform = transform; // Assuming the script is attached to the player GameObject
        lastPlayerPosition = playerTransform.position;
    }

    private void Update()
    {
        CheckAndSpawnBackground();
        //UpdateLastPosition();
    }

    private void CheckAndSpawnBackground()
    {
        float yDistance = Mathf.Abs(playerTransform.position.y - lastPlayerPosition.y);

        if (yDistance > 5f)
        {
            SpawnBackground(new Vector2(lastPlayerPosition.x, lastPlayerPosition.y + 30f));
        }
    }

    private void SpawnBackground(Vector2 position)
    {
        Instantiate(backgroundPrefab, position, Quaternion.identity);
    }

    private void UpdateLastPosition()
    {
        lastPlayerPosition = playerTransform.position;
    }
}     
