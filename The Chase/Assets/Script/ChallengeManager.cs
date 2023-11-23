using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    private int bikeDestroyed = 5;
    private int carDestroyed = 5;
    private int swatDestroyed = 5;

    public TextMeshProUGUI challenge1Text;
    public TextMeshProUGUI challenge2Text;
    public TextMeshProUGUI challenge3Text;

    public Button claim1;
    public Button claim2;
    public Button claim3;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private bool claimed1;
    private bool claimed2;
    private bool claimed3;

    void Start()
    {
        bikeDestroyed = PlayerPrefs.GetInt("BikeDestroyedCount", 0);
        carDestroyed = PlayerPrefs.GetInt("CarDestroyedCount", 0);
        swatDestroyed = PlayerPrefs.GetInt("SwatDestroyedCount", 0);

        // Load claimed status from PlayerPrefs
        claimed1 = PlayerPrefs.GetInt("Claimed1", 0) == 1;
        claimed2 = PlayerPrefs.GetInt("Claimed2", 0) == 1;
        claimed3 = PlayerPrefs.GetInt("Claimed3", 0) == 1;

        Challenge1(bikeDestroyed);
        Challenge2(carDestroyed);
        Challenge3(swatDestroyed);

        // Activate buttons based on challenge completion and claimed status
        ActivateButtons();

        // Subscribe button click events
        claim1.onClick.AddListener(() => ClaimReward(50, button1, ref claimed1, "Claimed1"));
        claim2.onClick.AddListener(() => ClaimReward(100, button2, ref claimed2, "Claimed2"));
        claim3.onClick.AddListener(() => ClaimReward(150, button3, ref claimed3, "Claimed3"));
    }

    private void Challenge1(int destroyed)
    {
        challenge1Text.text = bikeDestroyed.ToString() + "/5";
        if (destroyed >= 5)
        {
            Debug.Log("Challenge 1 completed");
            challenge1Text.text = "Completed";
        }
    }

    private void Challenge2(int destroyed)
    {
        challenge2Text.text = carDestroyed.ToString() + "/2";
        if (destroyed >= 2)
        {
            Debug.Log("Challenge 2 completed");
            challenge2Text.text = "Completed";
        }
    }

    private void Challenge3(int destroyed)
    {
        challenge3Text.text = swatDestroyed.ToString() + "/2";
        if (destroyed >= 2)
        {
            Debug.Log("Challenge 3 completed");
            challenge3Text.text = "Completed";
        }
    }

    private void ActivateButtons()
    {
        // Set buttons active or inactive based on challenge completion and claimed status
        button1.SetActive(bikeDestroyed >= 5 && !claimed1);
        button2.SetActive(carDestroyed >= 2 && !claimed2);
        button3.SetActive(swatDestroyed >= 2 && !claimed3);
    }

    private void ClaimReward(int rewardAmount, GameObject button, ref bool claimed, string playerPrefsKey)
    {
        if (!claimed)
        {
            int cash = PlayerPrefs.GetInt("CashCount", 0);
            cash += rewardAmount;
            PlayerPrefs.SetInt("CashCount", cash);
            PlayerPrefs.Save();

            button.SetActive(false);
            claimed = true;

            // Save claimed status
            PlayerPrefs.SetInt(playerPrefsKey, 1);
            PlayerPrefs.Save();
        }
    }
}  
