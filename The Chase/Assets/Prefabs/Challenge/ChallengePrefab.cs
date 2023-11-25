using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengePrefab : MonoBehaviour
{
    public string challengeName;
    public int threshold;
    public int currentProgress;
    public Button claimButton;
    public Slider progressSlider;
    public int reward;
    public bool isCompleted;

    // You can add any other properties or methods specific to the prefab here

    public void Initialize()
    {
        // Add initialization logic here if needed
    }
}
