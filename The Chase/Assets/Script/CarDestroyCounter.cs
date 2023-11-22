using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyCounter : MonoBehaviour
{
    // Static variable to keep track of the number of objects destroyed.
    public static int ObjectsDestroyedCount = 0;

    private void Start()
    {
        // Reset the count when the scene starts.
        ObjectsDestroyedCount = 0;
    }

    // Call this method whenever an object is destroyed to increment the count.
    public  void ObjectDestroyed()
    {
        ObjectsDestroyedCount++;
        Debug.Log("CAR Destroyed: " + ObjectsDestroyedCount);
    }
}
