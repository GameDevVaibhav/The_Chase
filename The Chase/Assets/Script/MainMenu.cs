using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public Button[] carButtons;

    public List<Button> enableCarButtons;

    public SpriteRenderer carSpriteRenderer;

    public List<Sprite> carSprites;
    private int selectedCarIndex = 0;

    public TextMeshProUGUI cash;
    public TextMeshProUGUI bounty;
    public TextMeshProUGUI notificationText;
    public AudioSource audioSource;

    public string selectedColor;

    private bool colorPanelActive = false;
    private bool challengePanelActive = false;
    private bool carSelectPanelActive = false;

    private Camera mainCamera; // Reference to the main camera.

     public GameObject buyPanel; // Reference to the panel containing Buy and No buttons
    public Button buyButton; // Reference to the Buy button on the panel
    public Button noButton; // Reference to the No button on the panel

    private int carIndexToEnable;

    private void Start()
    {
        // Find the main camera during runtime.
        mainCamera = Camera.main;

        bounty.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

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

            // Disable buttons with indices 7, 8, and 9
            if (i == 7 || i == 8 || i == 9)
            {
                carButtons[i].interactable = false;
            }
        }

        foreach (Button enableCarButton in enableCarButtons)
        {
            int indexToEnable = enableCarButtons.IndexOf(enableCarButton) + 7;
            int cost = int.Parse(RemoveNonNumericCharacters(enableCarButton.GetComponentInChildren<TextMeshProUGUI>().text)); // Parse the cash cost from the button text
            enableCarButton.onClick.AddListener(() => EnableCarButton(indexToEnable, enableCarButton, cost));

            // Check and set the initial state of the car button based on PlayerPrefs
            bool isCarEnabled = PlayerPrefs.GetInt($"CarButton_{indexToEnable}_Enabled", 0) == 1;
            carButtons[indexToEnable].interactable = isCarEnabled;
            enableCarButton.gameObject.SetActive(!isCarEnabled);
        }

        // Assign click listeners for the Buy and No buttons
        buyButton.onClick.AddListener(BuyCar);
        noButton.onClick.AddListener(CloseBuyPanel);

        notificationText.gameObject.SetActive(false);
    }

    private void Update()
    {
        cash.text = PlayerPrefs.GetInt("CashCount", 0).ToString();
    }

    private void PlayGame()
    {
        PlayerPrefs.SetString("selectedColor", selectedColor);
        PlayerPrefs.Save();
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

    private string RemoveNonNumericCharacters(string input)
    {
        // Remove non-numeric characters (except '-')
        return new string(input.Where(char.IsDigit).ToArray());
    }

    private void EnableCarButton(int index, Button enableCarButton, int cost)
    {
        // Show the Buy panel and store the car index to enable
        buyPanel.SetActive(true);
        carIndexToEnable = index;

        notificationText.gameObject.SetActive(false);
    }

    private void BuyCar()
    {
        // Enable the car button after buying
        int currentCash = PlayerPrefs.GetInt("CashCount", 0);
        int cost = int.Parse(RemoveNonNumericCharacters(enableCarButtons[carIndexToEnable - 7].GetComponentInChildren<TextMeshProUGUI>().text));

        if (currentCash >= cost)
        {
            carButtons[carIndexToEnable].interactable = true;
            enableCarButtons[carIndexToEnable - 7].gameObject.SetActive(false); // Deactivate the clicked enable button
            PlayerPrefs.SetInt($"CarButton_{carIndexToEnable}_Enabled", 1); // Save the enabled state
            PlayerPrefs.SetInt("CashCount", currentCash - cost); // Deduct the cash
            cash.text = (currentCash - cost).ToString();
            notificationText.color = Color.green;
            ShowNotification("Car Unlocked!!");
            audioSource.Play();
            PlayerPrefs.Save(); // Manually save PlayerPrefs changes
        }
        else
        {
            notificationText.color = Color.red;
            ShowNotification("Insufficient cash!");
            Debug.LogWarning("Insufficient cash to enable the car.");
            // Optionally show a message to the player about insufficient funds
        }

        // Close the Buy panel after processing
        buyPanel.SetActive(false);
    }

    private void CloseBuyPanel()
    {
        // Close the Buy panel without making any changes
        buyPanel.SetActive(false);
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
