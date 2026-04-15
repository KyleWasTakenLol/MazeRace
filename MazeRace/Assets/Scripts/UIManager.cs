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
        GameManager.Instance.onGameOver += StopTimer;
    }

    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onGameOver -= StopTimer;
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
        scoreText.text = "Score: " + newScore;
    }

    void StopTimer()
    {
        timerRunning = false;
    }
}