using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SirenLights : MonoBehaviour
{
    
    public Light2D light1;
    public Light2D light2;
    public float flickerSpeed = 1.0f;

    private bool isLight1Active = true;
    private float lastFlickerTime;

    void Start()
    {
        // Initialize the last flicker time.
        lastFlickerTime = Time.time;
    }

    void Update()
    {
        // Check if it's time to flicker the lights.
        if (Time.time - lastFlickerTime >= 1.0f / flickerSpeed)
        {
            // Toggle between the two lights.
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

            isLight1Active = !isLight1Active;

            // Update the last flicker time.
            lastFlickerTime = Time.time;
        }
    }
}