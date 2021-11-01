using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
            endGameMenu.SetActive(true);
    }
}