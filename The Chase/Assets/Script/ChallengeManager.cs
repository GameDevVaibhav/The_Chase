using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ChallengeManager : MonoBehaviour
{

    private int bikeDestroyed=5;
    private int carDestroyed = 5;
    private int swatDestroyed = 5;

    public TextMeshProUGUI challenge1Text;
    public TextMeshProUGUI challenge2Text;
    public TextMeshProUGUI challenge3Text;


    void Start()
    {
        
        bikeDestroyed = PlayerPrefs.GetInt("BikeDestroyedCount",0);
        carDestroyed = PlayerPrefs.GetInt("CarDestroyedCount", 0);
        swatDestroyed = PlayerPrefs.GetInt("SwatDestroyedCount", 0);

        Challenge1(bikeDestroyed);
        Challenge2(carDestroyed);
        Challenge3(swatDestroyed);

    }
   

   
    private void Challenge1(int destroyed)
    {
        if (destroyed >= 5)
        {
            Debug.Log("Challenge 1 completed");
        }
        challenge1Text.text = bikeDestroyed.ToString();

    }
    private void Challenge2(int destroyed)
    {
        if (destroyed >= 2)
        {
            Debug.Log("Challenge 2 completed");
        }
        challenge2Text.text = carDestroyed.ToString();

    }
    private void Challenge3(int destroyed)
    {
        if (destroyed >= 2)
        {
            Debug.Log("Challenge 3 completed");
        }
        challenge3Text.text = swatDestroyed.ToString();

    }
}
