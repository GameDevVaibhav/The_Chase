using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyCounter : MonoBehaviour
{
    // Key to use with PlayerPrefs to store and retrieve the count.
    private const string CarDestroyedCountKey = "CarDestroyedCount";
    private const string BikeDestroyedCountKey = "BikeDestroyedCount";
    private const string SwatDestroyedCountKey = "SwatDestroyedCount";


    // Static variable to keep track of the number of objects destroyed.
    public static int CarDestroyedCount { get; private set; }
    public static int BikeDestroyedCount { get; private set; }
    public static int SwatDestroyedCount { get; private set; }

    private void Start()
    {
        // Load the count from PlayerPrefs when the scene starts.
        CarDestroyedCount = PlayerPrefs.GetInt(CarDestroyedCountKey, 0);
        BikeDestroyedCount = PlayerPrefs.GetInt(BikeDestroyedCountKey, 0);
        SwatDestroyedCount = PlayerPrefs.GetInt(SwatDestroyedCountKey, 0);
    }

    // Call this method whenever an object is destroyed to increment the count.
    public  void CarDestroyed()
    {
        CarDestroyedCount++;
        

        // Save the count to PlayerPrefs.
        PlayerPrefs.SetInt(CarDestroyedCountKey, CarDestroyedCount);
        PlayerPrefs.Save();
    }
    public void BikeDestroyed()
    {
        BikeDestroyedCount++;
       

        // Save the count to PlayerPrefs.
        PlayerPrefs.SetInt(BikeDestroyedCountKey, BikeDestroyedCount);
        PlayerPrefs.Save();
    }
    public void SwatDestroyed()
    {
        SwatDestroyedCount++;


        // Save the count to PlayerPrefs.
        PlayerPrefs.SetInt(SwatDestroyedCountKey, SwatDestroyedCount);
        PlayerPrefs.Save();
    }
}
