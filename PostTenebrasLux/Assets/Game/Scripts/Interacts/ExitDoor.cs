using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private static Animator _animator;
    private static int _exitOpen;
    private static int _exitLocked;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _exitOpen = Animator.StringToHash("OpenExit");
        _exitLocked = Animator.StringToHash("LockedExit");
    }

    public static void LockedExit()
    {
        _animator.SetTrigger(_exitLocked);
    }

    public static void OpenExit()
    {
        _animator.SetBool(_exitOpen, true);
    }
}
