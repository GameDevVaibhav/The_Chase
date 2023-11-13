using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public ScoreManager scoreManager; // Reference to the ScoreManager script.
    public GameObject gameOverPanel; // Reference to the Game Over panel.

    public Text bountyText; // Reference to the Text component for displaying bounty.
    public Text cashText; // Reference to the Text component for displaying cash.

    private void Start()
    {
        // Disable the Game Over panel initially.
        gameOverPanel.SetActive(false);
    }

    // Call this method when the game is over.
    public void ShowGameOverUI()
    {
        // Enable the Game Over panel.
        gameOverPanel.SetActive(true);
        Debug.Log("Active UI");
        // Update the bounty and cash values on the Game Over panel.
        UpdateBountyText();
        UpdateCashText();
    }

    private void UpdateBountyText()
    {
        // Retrieve the bounty value from the ScoreManager.
        int bountyValue = scoreManager.score;

        // Update the Text component on the Game Over panel.
        bountyText.text = bountyValue.ToString();
    }

    private void UpdateCashText()
    {
        // Retrieve the cash value from the ScoreManager.
        int cashValue = scoreManager.cashCount;

        // Update the Text component on the Game Over panel.
        cashText.text = cashValue.ToString();
    }
}
