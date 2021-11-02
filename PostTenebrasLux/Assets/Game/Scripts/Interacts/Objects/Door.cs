using UnityEngine;

/*
 * Door
 * Script to animate Door being locked and opened. (Called in Interacts)
*/
public class Door : MonoBehaviour
{
    // animator and ints for parameter bool and trigger.
    private static Animator _animator;
    private static int _doorOpen;
    private static int _doorLocked;

    private void Start()
    {
        // set variables to Components and Parameters.
        _animator = GetComponent<Animator>();
        _doorOpen = Animator.StringToHash("OpenDoor");
        _doorLocked = Animator.StringToHash("LockedDoor");
    }

    // Set animation trigger to show that door is locked.
    public static void LockedDoor()
    {
        _animator.SetTrigger(_doorLocked);
    }

    // Set animation trigger to open door.
    public static void OpenDoor()
    {
        _animator.SetBool(_doorOpen, true);
    }
}