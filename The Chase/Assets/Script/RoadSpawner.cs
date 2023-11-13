using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadTile;
    Vector3 nextSpawnPoint;

    private void Start()
    {
        for(int i=0;i<3; i++)
        {
            SpawnRoad();
        }
    }

    public void  SpawnRoad()
    {
        GameObject temp=Instantiate(roadTile, nextSpawnPoint, Quaternion.identity);
        Collider2D rightTrigger = GameObject.Find("RightTrigger").GetComponent<Collider2D>();

        if (rightTrigger.IsTouching(GetComponent<Collider2D>()))
        {
            nextSpawnPoint = temp.transform.GetChild(3).transform.position;
        }
        else
        {
            nextSpawnPoint= temp.transform.GetChild(1).transform.position;
        }
        
    }
}
