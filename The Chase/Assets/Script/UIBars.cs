using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    public ScoreManager scoreManager;
    public BustingArea bustingArea;
    public float fillAmount;
    public float sliderValue;
    public Image heatBar;
    public Image healthBar;
    public float healthValue;
    public Slider bustingBar;
    public GameObject fillArea;
    public float previousThreshold;
    private float lerpSpeed;

    public PlayerCarCollision playerCarCollision;


    private void Update()
    {
        HeatBar();
        BustingBar();
        HealthBar();
    }

    private void HeatBar()
    {

        fillAmount = (float)scoreManager.score / (float)scoreManager.currentThreshold;
        fillAmount = Mathf.Clamp01(fillAmount);

        lerpSpeed = 3f * Time.deltaTime;
        heatBar.fillAmount = Mathf.Lerp(heatBar.fillAmount, fillAmount, lerpSpeed);
    }

    private void BustingBar()
    {
        sliderValue = bustingArea.activeTimer;
        if (sliderValue > 0)
        {
            fillArea.SetActive(true);
        }
        else
        {
            fillArea.SetActive(false);
        }
        lerpSpeed = 3f * Time.deltaTime;
        bustingBar.value = Mathf.Lerp(bustingBar.value, sliderValue, lerpSpeed);
    }

    private void HealthBar()
    {
        healthValue= (float)playerCarCollision.playerHealth / 10;
        if (healthValue ==1)
        {
            healthBar.enabled = false;
        }
        else
        {
            
            healthBar.enabled = true;
        }
        lerpSpeed = 3f * Time.deltaTime;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, healthValue, lerpSpeed);
    }
}
