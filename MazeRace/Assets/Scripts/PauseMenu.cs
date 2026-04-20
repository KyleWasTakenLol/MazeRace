using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Slider musicSlider;
    public Slider sfxSlider;

    private bool isPaused = false;

    void Start()
    {
        musicSlider.value = 0.5f;
        sfxSlider.value = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void OnMusicVolumeChanged(float value)
    {
        AudioManager.Instance.musicSource.volume = value;
    }

    public void OnSFXVolumeChanged(float value)
    {
        AudioManager.Instance.sfxSource.volume = value;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
        }
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}