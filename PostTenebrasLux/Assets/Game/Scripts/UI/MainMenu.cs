using System.Collections;
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
        StartCoroutine(PlayGame());
    }
    
    private static IEnumerator PlayGame()
    {
        SceneChanger.FadeToScene();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("02_Dungeon");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}