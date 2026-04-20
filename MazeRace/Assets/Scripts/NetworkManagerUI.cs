using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.SceneManagement;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    public TMP_InputField ipInput;
    public NetworkManager networkManager;

    public void OnHostClicked()
    {
        GameManager.Instance.SetMode(GameMode.Multiplayer);
        GameManager.Instance.ResetGame();

        UnityTransport transport = networkManager.GetComponent<UnityTransport>();
        transport.SetConnectionData("127.0.0.1", 7778);

        bool started = networkManager.StartHost();

        if (started)
        {
            networkManager.SceneManager.LoadScene("GameScene",
                LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Failed to start host!");
        }
    }

    public void OnClientClicked()
    {
        GameManager.Instance.SetMode(GameMode.Multiplayer);
        GameManager.Instance.ResetGame();

        string ip = ipInput.text;
        if (string.IsNullOrEmpty(ip))
        {
            ip = "127.0.0.1";
        }

        UnityTransport transport = networkManager.GetComponent<UnityTransport>();
        transport.SetConnectionData(ip, 7778);

        networkManager.StartClient();
    }

    public void OnSoloClicked()
    {
        GameManager.Instance.SetMode(GameMode.Solo);
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("SoloMode");
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}