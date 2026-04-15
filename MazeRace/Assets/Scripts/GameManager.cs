using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> onScoreChanged;
    public event Action onGameOver;

    private int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        onScoreChanged?.Invoke(score);
    }

    public void TriggerGameOver()
    {
        onGameOver?.Invoke();
    }

    public void ResetGame()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}