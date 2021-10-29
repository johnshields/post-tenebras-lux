using UnityEngine;

public class Door : MonoBehaviour
{
    private static Animator _animator;
    private static int _doorOpen;
    private static int _doorLocked;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _doorOpen = Animator.StringToHash("OpenDoor");
        _doorLocked = Animator.StringToHash("LockedDoor");
    }

    public static void LockedDoor()
    {
        _animator.SetTrigger(_doorLocked);
    }

    public static void OpenDoor()
    {
        _animator.SetBool(_doorOpen, true);
    }
}