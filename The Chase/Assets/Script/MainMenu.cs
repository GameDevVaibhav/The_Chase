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

    public Button redCar;
    public Button orangeCar;
    public Button blueCar;
    public Button purpleCar;
    public Button greenCar;
    public Button pinkCar;
    public Button blackCar;

    public SpriteRenderer carSpriteRenderer;

    [SerializeField]
    private Sprite redCarSprite;
    [SerializeField]
    private Sprite orangeCarSprite;
    [SerializeField]
    private Sprite blueCarSprite;
    [SerializeField]
    private Sprite purpleCarSprite;
    [SerializeField]
    private Sprite greenCarSprite;
    [SerializeField]
    private Sprite pinkCarSprite;
    [SerializeField]
    private Sprite blackCarSprite;


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

        string sprite = PlayerPrefs.GetString("SelectedCarSprite", "RedCar");
        carUpdate(sprite);


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

        redCar.onClick.AddListener(() => ChangeCar(redCarSprite));
        orangeCar.onClick.AddListener(() => ChangeCar(orangeCarSprite));
        blueCar.onClick.AddListener(() => ChangeCar(blueCarSprite));
        purpleCar.onClick.AddListener(() => ChangeCar(purpleCarSprite));
        greenCar.onClick.AddListener(() => ChangeCar(greenCarSprite));
        pinkCar.onClick.AddListener(() => ChangeCar(pinkCarSprite));
        blackCar.onClick.AddListener(() => ChangeCar(blackCarSprite));


    }

    private void Update()
    {
        cash.text = PlayerPrefs.GetInt("CashCount", 0).ToString();
    }
    private void PlayGame()
    {
        // Load the gameplay scene when the Play button is clicked.
        
        PlayerPrefs.SetString("selectedColor", selectedColor);
        PlayerPrefs.Save();
       // Debug.Log(selectedColor);
        SceneManager.LoadScene("Chase"); // Replace "GameplayScene" with the actual name of your gameplay scene.
    }

    private void ToggleColorSelectPanel()
    {
        colorPanelActive = !colorPanelActive;
        colorSelectPanel.SetActive(colorPanelActive);

        // Deactivate the other panel
        challengePanel.SetActive(false);
        challengePanelActive = false;
        carSelectPanel.SetActive(false);
        carSelectPanelActive= false;
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
        carSelectPanelActive= !carSelectPanelActive;
        carSelectPanel.SetActive(carSelectPanelActive);

        colorSelectPanel.SetActive(false);
        colorPanelActive = false;
        challengePanel.SetActive(false);
        challengePanelActive = false;
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
            
           // Debug.Log(selectedColor);
        }
        else
        {
            Debug.LogWarning("Main camera not found.");
        }
    }

    private void ChangeCar(Sprite newSprite)
    {
        if (carSpriteRenderer != null)
        {
            carSpriteRenderer.sprite = newSprite;

            // Save the selected sprite name to PlayerPrefs
            PlayerPrefs.SetString("SelectedCarSprite", newSprite.name);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Car SpriteRenderer not found.");
        }
    }

    private void carUpdate(string selectedCarSpriteName)
    {
        switch (selectedCarSpriteName)
        {
            case "RedCar":
                carSpriteRenderer.sprite = redCarSprite;
                break;
            case "OrangeCar":
                carSpriteRenderer.sprite = orangeCarSprite;
                break;
            case "BlueCar":
                carSpriteRenderer.sprite = blueCarSprite;
                break;
            case "PurpleCar":
                carSpriteRenderer.sprite = purpleCarSprite;
                break;
            case "GreenCar":
                carSpriteRenderer.sprite = greenCarSprite;
                break;
            case "PinkCar":
                carSpriteRenderer.sprite = pinkCarSprite;
                break;
            case "BlackCar":
                carSpriteRenderer.sprite = blackCarSprite;
                break;
            default:
                
                Debug.LogWarning("Selected car sprite not found. Using default sprite.");
                
                break;
        }
    }
}
