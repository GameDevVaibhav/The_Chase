using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//Blinking lights on barricade 
public class BaricetLights : MonoBehaviour
{
    public Light2D light1; 
    public Light2D light2; 
    public float blinkInterval = 0.5f; 

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

            isLight1Active = !isLight1Active; 

            timer = blinkInterval; 
        }
    }
}
