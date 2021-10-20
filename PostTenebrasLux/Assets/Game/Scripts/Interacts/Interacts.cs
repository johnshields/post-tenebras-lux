using UnityEngine;

public class Interacts : MonoBehaviour
{
    public GameObject clueOne;
    public GameObject clueTwo;
    public GameObject door;
    public GameObject doorLock;
    public GameObject puzzle;
    public GameObject chest;
    public GameObject keyOne;
    public GameObject keyTwo;
    public GameObject keyThree;

    private void OnTriggerEnter(Collider other)
    {
        // Clues
        if (other == clueOne.GetComponent<Collider>())
            print("This is [Clue 1]");

        if (other == clueTwo.GetComponent<Collider>())
            print("This is [Clue 2]");

        // Key 1 & Door
        if (other == keyOne.GetComponent<Collider>())
        {
            print("Key 1 for door found!");
            PlayerInventory.DoorKey += 1;
        }

        if (other == doorLock.GetComponent<Collider>() && PlayerInventory.DoorKey == 1)
        {
            print("Door unlocked!");
            Destroy(door);
        }
        else if (other == doorLock.GetComponent<Collider>())
        {
            print("Door locked!");
        } // end of Key 1 & Door

        if (other == keyTwo.GetComponent<Collider>())
            print("This is [key 2]");

        if (other == keyThree.GetComponent<Collider>())
            print("This is [key 3]");

        if (other == chest.GetComponent<Collider>())
            print("This is a [Chest]");

        // Puzzle
        if (other == puzzle.GetComponent<Collider>())
            print("This is a [Puzzle]...");
    }
}