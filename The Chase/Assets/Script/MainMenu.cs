using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button colorButton;
    public GameObject colorSelectPanel;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public string selectedColor;

    private bool colorPanelActive = false;

    private Camera mainCamera; // Reference to the main camera.

    private void Start()
    {
        // Find the main camera during runtime.
        mainCamera = Camera.main;

        // Hook up the button click events to the corresponding methods.
        playButton.onClick.AddListener(PlayGame);

        colorButton.onClick.AddListener(ToggleColorSelectPanel);

        selectedColor = "#FFD966";

        button1.onClick.AddListener(() => ChangeCameraColor("#FFD966"));
        button2.onClick.AddListener(() => ChangeCameraColor("#FF8F8F"));
        button3.onClick.AddListener(() => ChangeCameraColor("#A8DF8E"));
        button4.onClick.AddListener(() => ChangeCameraColor("#00FFF0"));
    }

    private void PlayGame()
    {
        // Load the gameplay scene when the Play button is clicked.
        
        PlayerPrefs.SetString("selectedColor", selectedColor);
        PlayerPrefs.Save();
        Debug.Log(selectedColor);
        SceneManager.LoadScene("Chase"); // Replace "GameplayScene" with the actual name of your gameplay scene.
    }

    private void ToggleColorSelectPanel()
    {
        colorPanelActive = !colorPanelActive;
        colorSelectPanel.SetActive(colorPanelActive);
    }

    private void ChangeCameraColor(string hexColor)
    {
        selectedColor= hexColor;
        Color newColor;
        ColorUtility.TryParseHtmlString(hexColor, out newColor);
        // Change the background color of the main camera.
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = newColor;
            
            Debug.Log(selectedColor);
        }
        else
        {
            Debug.LogWarning("Main camera not found.");
        }
    }
}
