using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to a Text component to display the score.
    public TextMeshProUGUI heatText; // Reference to a Text component to display the heat level.
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI notificationText;
    public int score = 0;
    private int heatLevel = 1;
    public int cashCount = 0;
    public int currentThreshold = 100; // Initial threshold for heat level 2.
    private int incrementThreshold = 200;
    private int incrementThresholdMultiplier = 1;
    private float timeSinceLastUpdate = 0;
    private float updateInterval = 1.0f;
    private int highscore = 0;
    private bool highscoreNotificationShown = false;


    private PlayerCarCollision playerCarCollision;

    // Define a delegate and event for the heat level change.
    public delegate void HeatLevelChanged(int newHeatLevel);
    public static event HeatLevelChanged OnHeatLevelChanged;

    private void Start()
    {
        scoreText.text = score.ToString();
        heatText.text = heatLevel.ToString();
        cashText.text = cashCount.ToString();

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        Debug.Log(highscore);

        // Load the cash count from PlayerPrefs or default to 0.
        cashCount = PlayerPrefs.GetInt("CashCount", 0);
        cashText.text = cashCount.ToString();

        playerCarCollision = FindObjectOfType<PlayerCarCollision>();

        notificationText.gameObject.SetActive(false);
    }

    private void Update()
    {
        SaveHighscore();
        if (playerCarCollision != null && playerCarCollision.isGameOver)
        {
            // If the game is over, stop updating the score.
            return;
        }
        timeSinceLastUpdate += Time.deltaTime;

        if ( timeSinceLastUpdate >= updateInterval)
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
        if (score >= currentThreshold )
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

    public void IncreaseCash(int amount)
    {
        cashCount += amount;
        cashText.text = cashCount.ToString();

        // Save the updated cash count to PlayerPrefs.
        PlayerPrefs.SetInt("CashCount", cashCount);
        PlayerPrefs.Save();
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
        if (!playerCarCollision.isGameOver)
        {
            IncreaseScore(bountyAmount);
        }
        
        // Increase the score when a police vehicle is destroyed.
        
    }

    private void SaveHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
            if (!highscoreNotificationShown)
            {
                ShowNotification("HIGH SCORE!");
                highscoreNotificationShown = true;
            }

            //highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }

    
    public void GameOver()
    {
        SaveHighscore();
    }

    private void ShowNotification(string message)
    {
        // Display the notification text with the specified message
        notificationText.text = message;
        notificationText.gameObject.SetActive(true);


        StartCoroutine(HideNotificationAfterDelay(2.0f));
    }

    private IEnumerator HideNotificationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        notificationText.gameObject.SetActive(false);
    }
}
