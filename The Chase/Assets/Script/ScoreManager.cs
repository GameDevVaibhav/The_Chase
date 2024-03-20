using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Score increases every second and with police car destruction additional score increased and at certain threshold of score Swat cars are spawned.
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI heatText; 
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI notificationText;
    public int score = 0;
    private int heatLevel = 1;
    public int cashCount = 0;
    public int currentThreshold = 100; 
    private int incrementThreshold = 200;
    private int incrementThresholdMultiplier = 1;
    private float timeSinceLastUpdate = 0;
    private float updateInterval = 1.0f;
    private int highscore = 0;
    private bool highscoreNotificationShown = false;
    private float startHighscore;



    private PlayerCarCollision playerCarCollision;

    
    public delegate void HeatLevelChanged(int newHeatLevel);
    public static event HeatLevelChanged OnHeatLevelChanged;

    private void Start()
    {
        scoreText.text = score.ToString();
        heatText.text = heatLevel.ToString();
        cashText.text = cashCount.ToString();

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        startHighscore = highscore;
        Debug.Log(highscore);

        
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
            
            return;
        }
        timeSinceLastUpdate += Time.deltaTime;

        if ( timeSinceLastUpdate >= updateInterval)
        {
            IncreaseScore(1); 
            timeSinceLastUpdate = 0;
        }
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

        
        if (score >= currentThreshold )
        {
            heatLevel++;
            heatText.text = heatLevel.ToString();
            UpdateHeatThreshold();

            
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

        
        PlayerPrefs.SetInt("CashCount", cashCount);
        PlayerPrefs.Save();
    }

    private void UpdateHeatThreshold()
    {
        
        currentThreshold = currentThreshold + (incrementThreshold * incrementThresholdMultiplier);
        incrementThresholdMultiplier++;
    }

    public void IncreaseBountyOnDestroy(int bountyAmount)
    {
        if (!playerCarCollision.isGameOver)
        {
            IncreaseScore(bountyAmount);
        }
        
        
        
    }

    private void SaveHighscore()
    {
        
        if (score > highscore)
        {
            highscore = score;
            
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
            if (!highscoreNotificationShown && startHighscore!=0)
            {
                ShowNotification("HIGH SCORE!");
                highscoreNotificationShown = true;
            }

            
        }
    }

    
    public void GameOver()
    {
        SaveHighscore();
    }

    private void ShowNotification(string message)
    {
        
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
