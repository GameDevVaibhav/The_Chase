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
    public Slider bustingBar;
    public GameObject fillArea;
    public float previousThreshold;
    private float lerpSpeed;


    private void Update()
    {
        HeatBar();
        BustingBar();
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
        lerpSpeed = 3f * Time.deltaTime;
        bustingBar.value = Mathf.Lerp(bustingBar.value, sliderValue, lerpSpeed);
    }
}
