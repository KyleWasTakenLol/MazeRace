using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI timeText;
    public TMP_InputField playerNameInput;

    private float completionTime;

    void Start()
    {
        completionTime = GameManager.Instance.GetCompletionTime();
        timeText.text = "Time: " + completionTime.ToString("F1") + "s";
    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        DatabaseManager.Instance.SaveHighScore(playerName, completionTime);
        SceneManager.LoadScene("HighScores");
    }

    public void OnPlayAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}