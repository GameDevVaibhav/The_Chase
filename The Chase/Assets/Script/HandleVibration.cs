using UnityEngine;

//Handle Vibrations. these are called when collisions occurs.
public class HandleVibration : MonoBehaviour
{
    private bool hapticFeedbackEnabled = true; 

    public void TriggerShortVibration()
    {
        if (hapticFeedbackEnabled)
        {
            Handheld.Vibrate();
           
        }
    }

    public void TriggerLongVibration()
    {
        if (hapticFeedbackEnabled )
        {
            
            VibrateForDuration(500);
            
        }
    }

    
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
