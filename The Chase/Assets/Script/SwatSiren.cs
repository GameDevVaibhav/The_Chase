using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwatSiren : MonoBehaviour
{
    public Light2D light1; // Reference to the first light.
    public Light2D light2; // Reference to the second light.
    public Light2D light3; // Reference to the third light.
    public float blinkInterval = 0.5f; // Time interval for blinking (adjust as needed).

    private float timer;
    private bool isBlinkingTogether = true;

    void Start()
    {
        timer = blinkInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (isBlinkingTogether)
            {
                light1.enabled = true;
                light2.enabled = true;
                light3.enabled = false;
            }
            else
            {
                light1.enabled = false;
                light2.enabled = false;
                light3.enabled = true;
            }

            isBlinkingTogether = !isBlinkingTogether;
            timer = blinkInterval;
        }
    }
}
