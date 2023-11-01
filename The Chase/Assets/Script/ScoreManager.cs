using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to a Text component to display the score.
    public Text heatText; // Reference to a Text component to display the heat level.
    private int score = 0;
    private int heatLevel = 1;
    private int currentThreshold = 100; // Initial threshold for heat level 2.
    private int incrementThreshold = 200;
    private int incrementThresholdMultiplier = 1;
    private float timeSinceLastUpdate = 0;
    private float updateInterval = 1.0f; // Interval to increase the score (e.g., 1 point per second).

    // Define a delegate and event for the heat level change.
    public delegate void HeatLevelChanged(int newHeatLevel);
    public static event HeatLevelChanged OnHeatLevelChanged;

    private void Start()
    {
        scoreText.text = score.ToString();
        heatText.text = heatLevel.ToString();
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

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
            heatText.text = heatLevel.ToString();
            UpdateHeatThreshold();

            // Trigger the heat level change event.
            if (OnHeatLevelChanged != null)
            {
                OnHeatLevelChanged(heatLevel);
            }
        }
    }

    private void UpdateHeatThreshold()
    {
        // Define how to calculate the new threshold based on the current heat level.
        // You can adjust this calculation as needed.
        currentThreshold = currentThreshold + (incrementThreshold * incrementThresholdMultiplier);
        incrementThresholdMultiplier++;
    }

    public void IncreaseBountyOnDestroy(int bountyAmount)
    {
        IncreaseScore(bountyAmount);
        // Increase the score when a police vehicle is destroyed.
        // You can add additional logic here if needed.
    }
}
