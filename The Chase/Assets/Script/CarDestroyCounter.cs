using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keep the count of destroyed cars and bike.
public class CarDestroyCounter : MonoBehaviour
{
    
    private const string CarDestroyedCountKey = "CarDestroyedCount";
    private const string BikeDestroyedCountKey = "BikeDestroyedCount";
    private const string SwatDestroyedCountKey = "SwatDestroyedCount";


   
    public static int CarDestroyedCount { get; private set; }
    public static int BikeDestroyedCount { get; private set; }
    public static int SwatDestroyedCount { get; private set; }

    private void Start()
    {
        
        CarDestroyedCount = PlayerPrefs.GetInt(CarDestroyedCountKey, 0);
        BikeDestroyedCount = PlayerPrefs.GetInt(BikeDestroyedCountKey, 0);
        SwatDestroyedCount = PlayerPrefs.GetInt(SwatDestroyedCountKey, 0);
    }

    
    public  void CarDestroyed()
    {
        CarDestroyedCount++;
        

        
        PlayerPrefs.SetInt(CarDestroyedCountKey, CarDestroyedCount);
        PlayerPrefs.Save();
    }
    public void BikeDestroyed()
    {
        BikeDestroyedCount++;
       

        
        PlayerPrefs.SetInt(BikeDestroyedCountKey, BikeDestroyedCount);
        PlayerPrefs.Save();
    }
    public void SwatDestroyed()
    {
        SwatDestroyedCount++;


        
        PlayerPrefs.SetInt(SwatDestroyedCountKey, SwatDestroyedCount);
        PlayerPrefs.Save();
    }
}
