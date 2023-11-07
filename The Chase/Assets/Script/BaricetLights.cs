using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BaricetLights : MonoBehaviour
{
    public Light2D light1; // Reference to the first light.
    public Light2D light2; // Reference to the second light.
    public float blinkInterval = 0.5f; // Time interval for blinking (adjust as needed).

    private float timer;
    private bool isLight1Active = true;

    void Start()
    {
        timer = blinkInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Toggle the lights.
            if (isLight1Active)
            {
                light1.enabled = false;
                light2.enabled = true;
            }
            else
            {
                light1.enabled = true;
                light2.enabled = false;
            }

            isLight1Active = !isLight1Active; // Toggle the flag.

            timer = blinkInterval; // Reset the timer.
        }
    }
}
