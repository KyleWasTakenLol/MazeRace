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
        networkManager.StartHost();
        networkManager.SceneManager.LoadScene(
            "GameScene", LoadSceneMode.Single);
    }

    public void OnClientClicked()
    {
        string ip = ipInput.text;
        if (string.IsNullOrEmpty(ip))
        {
            ip = "127.0.0.1";
        }

        UnityTransport transport = networkManager
            .GetComponent<UnityTransport>();
        transport.SetConnectionData(ip, 7777);

        networkManager.StartClient();
    }
}