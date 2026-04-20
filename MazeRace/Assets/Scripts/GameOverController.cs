using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
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

        if (GameManager.Instance.CurrentMode == GameMode.Solo)
        {
            winnerText.text = "Solo Complete!";
        }
        else
        {
            winnerText.text = "Game Over!";
        }
    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        if (GameManager.Instance.CurrentMode == GameMode.Solo)
        {
            DatabaseManager.Instance.SaveSoloHighScore(playerName, completionTime);
        }
        else
        {
            DatabaseManager.Instance.SaveHighScore(playerName, completionTime);
        }

        SceneManager.LoadScene("HighScores");
    }

    public void OnPlayAgain()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
        }
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}