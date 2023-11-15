using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        // Hook up the button click event to the PlayGame method.
        playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        // Load the gameplay scene when the Play button is clicked.
        SceneManager.LoadScene("Chase"); // Replace "GameplayScene" with the actual name of your gameplay scene.
    }
}
