using UnityEngine;
using Object = UnityEngine.Object;

public class Interacts : MonoBehaviour
{
    public GameObject clueOne;
    public GameObject clueTwo;

    public GameObject keyOne;
    public GameObject keyOneCollider;
    public GameObject keyTwo;
    public GameObject keyTwoCollider;
    public GameObject keyThree;
    public GameObject keyThreeCollider;

    public GameObject doorLock;
    public GameObject chestLock;
    public GameObject exitLock;

    public GameObject doorKeyUI;
    public GameObject chestKeyUI;
    public GameObject exitKeyUI;

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
        if (objectCollider == keyOneCollider.GetComponent<Collider>())
        {
            print("[Key 1] for door found!");
            doorKeyUI.SetActive(true);
            PlayerInventory.DoorKey += 1;
            Destroy(keyOne);
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
        if (chestCollider == keyTwoCollider.GetComponent<Collider>())
        {
            print("[Key 2] for [Chest] found!");
            chestKeyUI.SetActive(true);
            PlayerInventory.ChestKey += 1;
            Destroy(keyTwo);
        }

        if (chestCollider == chestLock.GetComponent<Collider>() && PlayerInventory.ChestKey == 1)
        {
            print("[Chest] unlocked!");
            Chest.OpenChest();
            Key.KeyJump();
            KeyCollider.KeyJump();
        }
        else if (chestCollider == chestLock.GetComponent<Collider>())
        {
            print("[Chest] locked!");
            Chest.LockedChest();
        }
    }

    private void UnlockExit(Object exitCollider)
    {
        if (exitCollider == keyThreeCollider.GetComponent<Collider>())
        {
            print("[Key 3] for [Exit] found!");
            exitKeyUI.SetActive(true);
            PlayerInventory.ExitKey += 1;
            Destroy(keyThree);
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