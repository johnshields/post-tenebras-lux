using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool Paused;
    
    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (Paused) ResumeGame();
        else PauseGame();
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        Paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
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
