using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        // if esc pressed pause game else resume.
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (Paused) ResumeGame();
        else PauseGame();
    }

    private void PauseGame()
    {
        // Pause - volume & time.
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        Paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        // Resume - volume & time.
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        Paused = false;
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}