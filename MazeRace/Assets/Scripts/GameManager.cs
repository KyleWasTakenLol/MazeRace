using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameMode
{
    Multiplayer,
    Solo
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> onScoreChanged;
    public event Action<string> onGameOver;

    private int score = 0;
    private const int WIN_CONDITION = 150;
    private float startTime;
    public GameMode CurrentMode { get; private set; }

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

    void Start()
    {
        startTime = Time.time;
    }

    public void SetMode(GameMode mode)
    {
        CurrentMode = mode;
    }

    public void AddScore(int points)
    {
        score += points;
        onScoreChanged?.Invoke(score);

        if (CurrentMode == GameMode.Multiplayer && score >= WIN_CONDITION)
        {
            TriggerGameOver("You Win!");
        }
    }

    public void TriggerGameOver(string message)
    {
        onGameOver?.Invoke(message);
        SceneManager.LoadScene("GameOver");
    }

    public void ResetGame()
    {
        score = 0;
        startTime = Time.time;
    }

    public int GetScore()
    {
        return score;
    }

    public float GetCompletionTime()
    {
        return Time.time - startTime;
    }
}