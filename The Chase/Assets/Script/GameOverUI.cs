using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Activates panel when game is game is over and shows score and has mainmenu button and restart button.
public class GameOverUI : MonoBehaviour
{

    public ScoreManager scoreManager; 
    public GameObject gameOverPanel; 
    public Text bountyText; 
    public Text cashText; 
    public Button restartButton; 
    public Button homeButton;

    private void Start()
    {
        
        gameOverPanel.SetActive(false);

        
        restartButton.onClick.AddListener(RestartGame);
        homeButton.onClick.AddListener(MainMenu);
    }

    
    public void ShowGameOverUI()
    {
        
        gameOverPanel.SetActive(true);
        
        
        UpdateBountyText();
        UpdateCashText();
    }

    private void UpdateBountyText()
    {
        
        int bountyValue = scoreManager.score;

        
        bountyText.text =   bountyValue.ToString();
    }

    private void UpdateCashText()
    {
       
        int cashValue = scoreManager.cashCount;

        
        cashText.text =  cashValue.ToString();
    }

    private void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
