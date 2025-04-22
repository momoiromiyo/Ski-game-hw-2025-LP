using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public TextMeshProUGUI leaderboardText;

    private const string keyPrefix = "Score_";
    private const int maxScores = 5;

    private void Start()
    {
        leaderboardPanel.SetActive(false);
    }

    public void SaveResult(float time, int points)
    {
        // Save your real score
        string result = $"{time:F2}s - {points} points";
        List<string> scores = new List<string> { result };

        // Fill the rest with clean dummy entries
        for (int i = 1; i < maxScores; i++)
        {
            scores.Add("0.00s - 0 points");
        }

        // Store them all in PlayerPrefs
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetString(keyPrefix + i, scores[i]);
        }

        PlayerPrefs.Save();
    }

    public void ShowResults()
    {
        leaderboardPanel.SetActive(true);
        leaderboardText.text = "Leaderboard:\n";

        for (int i = 0; i < maxScores; i++)
        {
            string entry = PlayerPrefs.GetString(keyPrefix + i, "0.00s - 0 points");
            leaderboardText.text += $"{i + 1}. {entry}\n";
        }
    }
}