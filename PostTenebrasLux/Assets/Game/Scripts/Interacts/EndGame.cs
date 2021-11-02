using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * EndGame
 * Script to display the Game has ended to the player.
*/
public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameMenu;
    
    // if Player collides display the end game menu and call fadeOutMainMenu.
    private void OnTriggerEnter(Collider other)
    {
        if (other != player.GetComponent<Collider>()) return;
        endGameMenu.SetActive(true);
        StartCoroutine(FadeOutMainMenu());
    }
    
    // Fade out to 01_MainMenu Scene using SceneChanger.
    private static IEnumerator FadeOutMainMenu()
    {
        yield return new WaitForSeconds(4);
        SceneChanger.FadeToScene();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("01_MainMenu");
    }
}