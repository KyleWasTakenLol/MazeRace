using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class BackButton : MonoBehaviour
{
    public void OnBackClicked()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
        }
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}