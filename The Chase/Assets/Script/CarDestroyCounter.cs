using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyCounter : MonoBehaviour
{
    // Key to use with PlayerPrefs to store and retrieve the count.
    private const string DestroyedCountKey = "DestroyedCount";

    // Static variable to keep track of the number of objects destroyed.
    public static int ObjectsDestroyedCount { get; private set; }

    private void Start()
    {
        // Load the count from PlayerPrefs when the scene starts.
        ObjectsDestroyedCount = PlayerPrefs.GetInt(DestroyedCountKey, 0);
    }

    // Call this method whenever an object is destroyed to increment the count.
    public  void ObjectDestroyed()
    {
        ObjectsDestroyedCount++;
        Debug.Log("Objects Destroyed: " + ObjectsDestroyedCount);

        // Save the count to PlayerPrefs.
        PlayerPrefs.SetInt(DestroyedCountKey, ObjectsDestroyedCount);
        PlayerPrefs.Save();
    }
}
