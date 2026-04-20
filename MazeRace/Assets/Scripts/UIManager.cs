using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f;
    private bool timerRunning = false;

    void OnEnable()
    {
        GameManager.Instance.onScoreChanged += UpdateScore;
        GameManager.Instance.onGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onGameOver -= HandleGameOver;
    }

    void Start()
    {
        timerRunning = true;
        UpdateScore(0);
    }

    void Update()
    {
        if (!timerRunning) return;
        elapsedTime += Time.deltaTime;
        timerText.text = "Time: " + Mathf.FloorToInt(elapsedTime) + "s";
    }

    void UpdateScore(int newScore)
    {
        if (GameManager.Instance.CurrentMode == GameMode.Solo)
            scoreText.text = "Points: " + newScore;
        else
            scoreText.text = "Points: " + newScore + " / 150";
    }
    void HandleGameOver(string message)
    {
        timerRunning = false;
        scoreText.text = message;
    }
}