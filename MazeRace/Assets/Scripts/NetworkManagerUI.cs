using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.SceneManagement;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    public TMP_InputField ipInput;

    public void OnHostClicked()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(
            "GameScene", LoadSceneMode.Single);
    }

    public void OnClientClicked()
    {
        string ip = ipInput.text;
        if (string.IsNullOrEmpty(ip))
        {
            ip = "127.0.0.1";
        }

        UnityTransport transport = NetworkManager.Singleton
            .GetComponent<UnityTransport>();
        transport.SetConnectionData(ip, 7777);

        NetworkManager.Singleton.StartClient();
    }
}