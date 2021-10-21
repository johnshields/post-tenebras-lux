using UnityEngine;

public class Door : MonoBehaviour
{
    private static Animator _animator;
    private static int _doorOpen;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _doorOpen = Animator.StringToHash("OpenDoor");
    }

    public static void OpenDoor()
    {
        _animator.SetBool(_doorOpen, true);
    }
}
