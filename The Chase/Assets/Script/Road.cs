using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    RoadSpawner roadSpawner;


    private void Start()
    {
        roadSpawner= GameObject.FindObjectOfType<RoadSpawner>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        roadSpawner.SpawnRoad();
        Debug.Log("Player enter the Top trigger!");
        
    }
}