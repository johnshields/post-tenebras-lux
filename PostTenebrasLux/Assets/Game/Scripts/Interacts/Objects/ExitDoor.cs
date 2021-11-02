using UnityEngine;

/*
 * ExitDoor
 * Script to animate Exit Door being locked and opened. (Called in Interacts)
*/
public class ExitDoor : MonoBehaviour
{
    // animator and ints for parameter bool and trigger.
    private static Animator _animator;
    private static int _exitOpen;
    private static int _exitLocked;

    private void Start()
    {
        // set variables to Components and Parameters.
        _animator = GetComponent<Animator>();
        _exitOpen = Animator.StringToHash("OpenExit");
        _exitLocked = Animator.StringToHash("LockedExit");
    }

    // Set animation trigger to show that exit is locked.
    public static void LockedExit()
    {
        _animator.SetTrigger(_exitLocked);
    }

    // Set animation trigger to open exit.
    public static void OpenExit()
    {
        _animator.SetBool(_exitOpen, true);
    }
}