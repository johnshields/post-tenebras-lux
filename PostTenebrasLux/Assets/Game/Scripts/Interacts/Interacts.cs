using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class Interacts : MonoBehaviour
{
    public GameObject clueOne, scrollOne, clueTwo, scrollTwo;
    public GameObject keyOne, keyOneCollider, keyTwo, keyTwoCollider, keyThree, keyThreeCollider;
    public GameObject doorLock, chestLock, exitLock;
    public GameObject doorKeyUI, chestKeyUI, exitKeyUI;
    
    public AudioClip pickupSound, lockedSound, unlockedSound;

    private void OnTriggerEnter(Collider other)
    {
        // Clues
        if (other == clueOne.GetComponent<Collider>())
        {
            print("This is [Clue 1]");
            scrollOne.SetActive(true);
            StartCoroutine(Waiter(scrollOne));
        }

        if (other == clueTwo.GetComponent<Collider>())
        {
            print("This is [Clue 2]");
            scrollTwo.SetActive(true);  
            StartCoroutine(Waiter(scrollTwo));
        }

        UnlockDoor(other);
        UnlockChest(other);
        UnlockExit(other);
    }

    private void UnlockDoor(Object objectCollider)
    {
        if (objectCollider == keyOneCollider.GetComponent<Collider>())
        {
            print("[Key 1] for door found!");
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            doorKeyUI.SetActive(true);
            PlayerInventory.DoorKey += 1;
            keyOneCollider.transform.position = Vector3.up;
            Destroy(keyOne);
        }

        if (objectCollider == doorLock.GetComponent<Collider>() && PlayerInventory.DoorKey == 1)
        {
            print("Door unlocked!");
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            doorLock.transform.position = Vector3.up;
            Door.OpenDoor();
        }
        else if (objectCollider == doorLock.GetComponent<Collider>())
        {
            print("Door locked!");
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
            Door.LockedDoor();
        }
    }

    private void UnlockChest(Object chestCollider)
    {
        if (chestCollider == keyTwoCollider.GetComponent<Collider>())
        {
            print("[Key 2] for [Chest] found!");
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            chestKeyUI.SetActive(true);
            PlayerInventory.ChestKey += 1;
            keyTwoCollider.transform.position = Vector3.up;
            Destroy(keyTwo);
        }

        if (chestCollider == chestLock.GetComponent<Collider>() && PlayerInventory.ChestKey == 1)
        {
            print("[Chest] unlocked!");
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            Chest.OpenChest();
            Key.KeyJump();
            chestLock.transform.position = Vector3.up;
            KeyCollider.KeyJump();
        }
        else if (chestCollider == chestLock.GetComponent<Collider>())
        {
            print("[Chest] locked!");
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
            Chest.LockedChest();
        }
    }

    private void UnlockExit(Object exitCollider)
    {
        if (exitCollider == keyThreeCollider.GetComponent<Collider>())
        {
            print("[Key 3] for [Exit] found!");
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            exitKeyUI.SetActive(true);
            KeyCollider.BackJump();
            PlayerInventory.ExitKey += 1;
            Destroy(keyThree);
        }

        if (exitCollider == exitLock.GetComponent<Collider>() && PlayerInventory.ExitKey == 1)
        {
            print("[Exit] unlocked!");
            exitLock.transform.position = Vector3.up;
            AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
            ExitDoor.OpenExit();
        }
        else if (exitCollider == exitLock.GetComponent<Collider>())
        {
            print("[Exit] locked!");
            AudioSource.PlayClipAtPoint(lockedSound, transform.position);
            ExitDoor.LockedExit();
        }
    }

    private IEnumerator Waiter(GameObject scroll)
    {
        yield return new WaitForSeconds(3);
        scroll.SetActive(false);
    }
}