using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Timer timer;
    public Leaderboard leaderboard;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointText;

    private int points = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        GameEvents.raceStart += StartRace;
        GameEvents.raceEnd += EndRace;
    }

    private void OnDisable()
    {
        GameEvents.raceStart -= StartRace;
        GameEvents.raceEnd -= EndRace;
    }

    private void Update()
    {
        timeText.text = $"Time: {timer.GetTime():F2}s";
        pointText.text = $"Points: {points}";
    }

    private void StartRace()
    {
        points = 0;
    }

    private void EndRace()
    {
        leaderboard.SaveResult(timer.GetTime(), points);
        leaderboard.ShowResults();
    }

    public void AddPoint(int value)
    {
        points += value;
    }

    public int GetPoints()
    {
        return points;
    }
}