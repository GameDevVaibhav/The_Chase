using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to a Text component to display the score.
    public Text Heat;
    private int score = 0;
    private int heatLevel = 1;
    private int currentThreshold = 100; // Initial threshold for heat level 2.
    private int incrementThreshold = 200;
    private int incremnetThresholdMultiplier = 1;
    private float timeSinceLastUpdate = 0;
    private float updateInterval = 1.0f; // Interval to increase score (e.g., 1 point per second).

    private void Start()
    {
        scoreText.text =  score.ToString();
        Heat.text = heatLevel.ToString();
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        Heat.text = heatLevel.ToString();
        if (timeSinceLastUpdate >= updateInterval)
        {
            IncreaseScore(1); // Increase score by 1 point every updateInterval seconds.
            timeSinceLastUpdate = 0;
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

        // Check and update the heat level
        if (score >= currentThreshold)
        {
            heatLevel++;
            Debug.Log(heatLevel);
            UpdateHeatThreshold();
            
            // You can add code here to handle changes related to the new heat level.
        }
    }

    private void UpdateHeatThreshold()
    {
        // Define how to calculate the new threshold based on the current heat level.
        // You can adjust this calculation as needed.
        currentThreshold = currentThreshold + (incrementThreshold * incremnetThresholdMultiplier);
        incremnetThresholdMultiplier++;
        Debug.Log(currentThreshold);
        
    }

    public void IncreaseBountyOnDestroy(int bountyAmount)
    {
        IncreaseScore(bountyAmount);
        // Increase the score when a police vehicle is destroyed.
        // You can add additional logic here if needed.
    }
}
