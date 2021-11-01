using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            endGameMenu.SetActive(true);
            StartCoroutine(FadeOutMainMenu());
        }
    }
    
    private static IEnumerator FadeOutMainMenu()
    {
        yield return new WaitForSeconds(4);
        SceneChanger.FadeToScene();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("01_MainMenu");
    }
}