using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>()) 
            print("You escaped the dungeon!");
    }
}
