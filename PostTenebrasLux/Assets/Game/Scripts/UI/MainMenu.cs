using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("02_Dungeon");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}