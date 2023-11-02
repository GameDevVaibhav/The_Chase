using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float fillAmount;
    public Image heatBar;
    public float previousThreshold;
    private float lerpSpeed;


    private void Update()
    {
        fillAmount = (float)scoreManager.score / (float)scoreManager.currentThreshold;
        fillAmount = Mathf.Clamp01(fillAmount);

        lerpSpeed=3f*Time.deltaTime;
        heatBar.fillAmount= Mathf.Lerp(heatBar.fillAmount, fillAmount, lerpSpeed);
    }
}
