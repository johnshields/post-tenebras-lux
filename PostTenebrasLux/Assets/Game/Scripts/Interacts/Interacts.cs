using System.Collections;
using UnityEngine;

/*
 * Interacts
 * Main interactions script for interaction with the Clues, Doors, Chest and Exit Systems.
*/
public class Interacts : MonoBehaviour
{
    public GameObject clueOne, scrollOne, clueTwo, scrollTwo;
    public GameObject keyOne, keyOneCollider, keyTwo, keyTwoCollider, keyThree, keyThreeCollider;
    public GameObject doorLock, chestLock, exitLock;
    public GameObject doorKeyUI, chestKeyUI, exitKeyUI;

    public AudioClip pickupSound, lockedSound, unlockedSound;

    // Function for interactions of objects.
    private void OnTriggerEnter(Collider other)
    {
        // Clues - if player collides with a clue (scroll) display the scroll UI and play a sound.
        if (other == clueOne.GetComponent<Collider>())
        {
            scrollOne.SetActive(true);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            StartCoroutine(Waiter(scrollOne)); // Call Waiter to have scroll UI disappear after 3 seconds.
        }

        if (other == clueTwo.GetComponent<Collider>())
        {
            scrollTwo.SetActive(true);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            StartCoroutine(Waiter(scrollTwo));
        }

        // Call all other functions for interactions to clean up code.
        UnlockDoor(other);
        UnlockChest(other);
        UnlockExit(other);
    }

    // Door system to allow player to collect a key to open door.
    private void UnlockDoor(Object objectCollider)
    {
        // collect key, play sound, add to PlayerInventory + UI and move the collider.
        if (objectCollider == keyOneCollider.GetComponent<Collider>())
        {
            PlayerInventory.DoorKey += 1;
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(keyOne);
            doorKeyUI.SetActive(true); // add key to Inventory UI.
            keyOneCollider.transform.position = Vector3.up; // prevent further collisions.
        }

        // Open door if player has it's key - else keep door locked.
        if (objectCollider == doorLock.GetComponent<Collider>() && PlayerInventory.DoorKey == 1)
        {
            Door.OpenDoor(); // call open animation from Door Script.
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            doorLock.transform.position = Vector3.up;
        }
        else if (objectCollider == doorLock.GetComponent<Collider>())
        {
            Door.LockedDoor();
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    // Chest system to allow player to collect a key to open the chest.
    private void UnlockChest(Object chestCollider)
    {
        // collect key
        if (chestCollider == keyTwoCollider.GetComponent<Collider>())
        {
            PlayerInventory.ChestKey += 1;
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(keyTwo);
            chestKeyUI.SetActive(true);
            keyTwoCollider.transform.position = Vector3.up;
        }

        // open chest if player has it's key - else keep chest locked.
        if (chestCollider == chestLock.GetComponent<Collider>() && PlayerInventory.ChestKey == 1)
        {
            // All 3 animations - Open chest and two for the key and it's collider.
            Chest.OpenChest();
            Key.KeyJump();
            KeyCollider.KeyJump();
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            chestLock.transform.position = Vector3.up;
        }
        else if (chestCollider == chestLock.GetComponent<Collider>())
        {
            Chest.LockedChest();
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    // Exit system to allow player to collect a key to open the exit.
    private void UnlockExit(Object exitCollider)
    {
        // collect key
        if (exitCollider == keyThreeCollider.GetComponent<Collider>())
        {
            PlayerInventory.ExitKey += 1;
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(keyThree);
            exitKeyUI.SetActive(true);
            KeyCollider.BackJump();
        }

        // open exit if player has it's key - else keep exit locked.
        if (exitCollider == exitLock.GetComponent<Collider>() && PlayerInventory.ExitKey == 1)
        {
            ExitDoor.OpenExit();
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            exitLock.transform.position = Vector3.up;
        }
        else if (exitCollider == exitLock.GetComponent<Collider>())
        {
            ExitDoor.LockedExit();
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    // Function to have the Scroll UIs only display for 3 seconds.
    private IEnumerator Waiter(GameObject scroll)
    {
        yield return new WaitForSeconds(3);
        scroll.SetActive(false);
    }
}