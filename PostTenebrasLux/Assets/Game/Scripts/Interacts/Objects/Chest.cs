using UnityEngine;

/*
 * Chest
 * Script to animate Chest being locked and opened. (Called in Interacts)
*/
public class Chest : MonoBehaviour
{
    // animator and ints for parameter bool and trigger.
    private static Animator _animator;
    private static int _chestOpen;
    private static int _chestLocked;

    private void Start()
    {
        // set variables to Components and Parameters.
        _animator = GetComponent<Animator>();
        _chestOpen = Animator.StringToHash("OpenChest");
        _chestLocked = Animator.StringToHash("LockedChest");
    }

    // Set animation trigger to show that chest is locked.
    public static void LockedChest()
    {
        _animator.SetTrigger(_chestLocked);
    }

    // Set animation trigger to open chest.
    public static void OpenChest()
    {
        _animator.SetBool(_chestOpen, true);
    }
}