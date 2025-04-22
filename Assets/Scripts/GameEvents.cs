using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RaceEvent();
    public static event RaceEvent raceStart;
    public static event RaceEvent raceEnd;

    public static void CallRaceStart()
    {
        raceStart?.Invoke();
    }

    public static void CallRaceEnd()
    {
        raceEnd?.Invoke();
    }
}