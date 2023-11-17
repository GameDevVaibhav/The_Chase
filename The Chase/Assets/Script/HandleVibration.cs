using UnityEngine;

public class HandleVibration : MonoBehaviour
{
    private bool hapticFeedbackEnabled = true; // Toggle this based on device support.

    public void TriggerShortVibration()
    {
        if (hapticFeedbackEnabled /*&& SystemInfo.supportsVibration*/)
        {
            Handheld.Vibrate();
            Debug.Log("Short Vibrations");
        }
    }

    public void TriggerLongVibration()
    {
        if (hapticFeedbackEnabled /*&& SystemInfo.supportsVibration*/)
        {
            // Adjust the duration as needed.
            VibrateForDuration(500);
            Debug.Log("Long Vibrations");
        }
    }

    // Helper method for custom vibration duration.
    private void VibrateForDuration(long milliseconds)
    {
        if (hapticFeedbackEnabled && SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
            Invoke("StopVibration", milliseconds / 1000f);
        }
    }

    private void StopVibration()
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
    }
}
