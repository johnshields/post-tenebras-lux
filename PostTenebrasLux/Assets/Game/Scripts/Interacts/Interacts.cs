using UnityEngine;
using Object = UnityEngine.Object;

public class Interacts : MonoBehaviour
{
    public GameObject clueOne;
    public GameObject clueTwo;
    
    public GameObject keyOne;
    public GameObject keyTwo;
    public GameObject keyThree;
    
    public GameObject doorLock;
    public GameObject chest;
    public GameObject chestLock;
    public GameObject exitLock;

    private void OnTriggerEnter(Collider other)
    {
        // Clues
        if (other == clueOne.GetComponent<Collider>())
            print("This is [Clue 1]");

        if (other == clueTwo.GetComponent<Collider>())
            print("This is [Clue 2]");

        UnlockDoor(other);
        UnlockChest(other);
        UnlockExit(other);
    }

    private void UnlockDoor(Object objectCollider)
    {
        if (objectCollider == keyOne.GetComponent<Collider>())
        {
            print("[Key 1] for door found!");
            PlayerInventory.DoorKey += 1;
        }

        if (objectCollider == doorLock.GetComponent<Collider>() && PlayerInventory.DoorKey == 1)
        {
            print("Door unlocked!");
            Door.OpenDoor();
        }
        else if (objectCollider == doorLock.GetComponent<Collider>())
        {
            print("Door locked!");
        }
    }
    
    private void UnlockChest(Object chestCollider)
    {
        if (chestCollider == keyTwo.GetComponent<Collider>()) 
        {
            print("[Key 2] for [Chest] found!");
            PlayerInventory.ChestKey += 1;
        }

        if (chestCollider == chestLock.GetComponent<Collider>() && PlayerInventory.ChestKey == 1)
        {
            print("[Chest] unlocked!");
            Destroy(chest);
        }
        else if (chestCollider == chestLock.GetComponent<Collider>())
        {
            print("[Chest] locked!");
        }
    }
    
    private void UnlockExit(Object exitCollider)
    {
        if (exitCollider == keyThree.GetComponent<Collider>()) 
        {
            print("[Key 3] for [Exit] found!");
            PlayerInventory.ExitKey += 1;
        }

        if (exitCollider == exitLock.GetComponent<Collider>() && PlayerInventory.ExitKey == 1)
        {
            print("[Exit] unlocked!");
        }
        else if (exitCollider == exitLock.GetComponent<Collider>())
        {
            print("[Exit] locked!");
        }
    }
}