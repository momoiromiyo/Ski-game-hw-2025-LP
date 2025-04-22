using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerRunning = false;
    private float raceTime = 0;

    private void Update()
    {
        if (timerRunning)
        {
            raceTime += Time.deltaTime; // Increase race time as long as the timer is running
        }
    }

    private void OnEnable()
    {
        // Subscribe to events when the object is enabled
        GameEvents.raceStart += StartRace;
        GameEvents.raceEnd += StopRace;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks when the object is disabled
        GameEvents.raceStart -= StartRace;
        GameEvents.raceEnd -= StopRace;
    }

    private void StartRace()
    {
        raceTime = 0;  // Reset the race time to 0
        timerRunning = true;  // Start the timer
    }

    private void StopRace()
    {
        timerRunning = false;  // Stop the timer
    }

    public float GetTime()
    {
        return raceTime;  // Return the current race time
    }
}