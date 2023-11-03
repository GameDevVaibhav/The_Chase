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
    public CanvasGroup bustingBarGroup;
    public CanvasGroup healthBarGroup;
    

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
        
        lerpSpeed = 3f * Time.deltaTime;
        bustingBar.value = Mathf.Lerp(bustingBar.value, sliderValue, lerpSpeed);
        float alpha = Mathf.Lerp(0, 1, sliderValue); // Fading in.
        if (sliderValue == 0 && bustingBarGroup.alpha > 0)
        {
            alpha = Mathf.Lerp(bustingBarGroup.alpha, 0, lerpSpeed); // Fading out when sliderValue is zero.
        }
        bustingBarGroup.alpha = alpha;
    }

    private void HealthBar()
    {
        healthValue= (float)playerCarCollision.playerHealth / 10;
      
        lerpSpeed = 3f * Time.deltaTime;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, healthValue, lerpSpeed);
        if (healthValue == 1 && healthBarGroup.alpha > 0)
        {
            float alpha = Mathf.Lerp(healthBarGroup.alpha, 0, lerpSpeed); // Fading out.
            healthBarGroup.alpha = alpha;
        }
        else
        {
            float alpha = Mathf.Lerp(healthBarGroup.alpha, 1, lerpSpeed); // Fading in.
            healthBarGroup.alpha = alpha;
        }
    }
}
