using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button colorButton;
    public Button challengeButton;
    public Button carSelectButton;
    public GameObject colorSelectPanel;
    public GameObject challengePanel;
    public GameObject carSelectPanel;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Button[] carButtons; // Array for car selection buttons

    public SpriteRenderer carSpriteRenderer;

    public List<Sprite> carSprites;
    private int selectedCarIndex = 0;

    public TextMeshProUGUI cash;

    public string selectedColor;

    private bool colorPanelActive = false;
    private bool challengePanelActive = false;
    private bool carSelectPanelActive = false;

    private Camera mainCamera; // Reference to the main camera.

    private void Start()
    {
        // Find the main camera during runtime.
        mainCamera = Camera.main;

        selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);
        carUpdate(selectedCarIndex);

        // Hook up the button click events to the corresponding methods.
        playButton.onClick.AddListener(PlayGame);

        colorButton.onClick.AddListener(ToggleColorSelectPanel);
        challengeButton.onClick.AddListener(ToggleChallengePanel);
        carSelectButton.onClick.AddListener(ToggleCarSelectPanel);

        selectedColor = "#FFD966";

        button1.onClick.AddListener(() => ChangeCameraColor("#FFD966"));
        button2.onClick.AddListener(() => ChangeCameraColor("#FF8F8F"));
        button3.onClick.AddListener(() => ChangeCameraColor("#A8DF8E"));
        button4.onClick.AddListener(() => ChangeCameraColor("#00FFF0"));

        // Assign click listeners for each car button in the array
        for (int i = 0; i < carButtons.Length; i++)
        {
            int index = i; // Capture the current value of i for the lambda function
            carButtons[i].onClick.AddListener(() => ChangeCar(index));
        }
    }

    private void Update()
    {
        cash.text = PlayerPrefs.GetInt("CashCount", 0).ToString();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Chase");
    }

    private void ToggleColorSelectPanel()
    {
        colorPanelActive = !colorPanelActive;
        colorSelectPanel.SetActive(colorPanelActive);

        challengePanel.SetActive(false);
        challengePanelActive = false;
        carSelectPanel.SetActive(false);
        carSelectPanelActive = false;
    }

    private void ToggleChallengePanel()
    {
        challengePanelActive = !challengePanelActive;
        challengePanel.SetActive(challengePanelActive);

        colorSelectPanel.SetActive(false);
        colorPanelActive = false;
        carSelectPanel.SetActive(false);
        carSelectPanelActive = false;
    }

    private void ToggleCarSelectPanel()
    {
        carSelectPanelActive = !carSelectPanelActive;
        carSelectPanel.SetActive(carSelectPanelActive);

        colorSelectPanel.SetActive(false);
        colorPanelActive = false;
        challengePanel.SetActive(false);
        challengePanelActive = false;
    }

    private void ChangeCameraColor(string hexColor)
    {
        selectedColor = hexColor;
        Color newColor;
        ColorUtility.TryParseHtmlString(hexColor, out newColor);

        if (mainCamera != null)
        {
            mainCamera.backgroundColor = newColor;
        }
        else
        {
            Debug.LogWarning("Main camera not found.");
        }
    }

    private void ChangeCar(int newIndex)
    {
        if (newIndex >= 0 && newIndex < carSprites.Count)
        {
            selectedCarIndex = newIndex;
            carSpriteRenderer.sprite = carSprites[selectedCarIndex];
            PlayerPrefs.SetInt("SelectedCarIndex", selectedCarIndex);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Invalid car index.");
        }
    }

    private void carUpdate(int index)
    {
        if (index >= 0 && index < carSprites.Count)
        {
            carSpriteRenderer.sprite = carSprites[index];
        }
        else
        {
            Debug.LogWarning("Selected car index not found. Using default sprite.");
        }
    }
}
