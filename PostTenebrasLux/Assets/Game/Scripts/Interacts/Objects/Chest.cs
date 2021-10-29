using UnityEngine;

public class Chest : MonoBehaviour
{
    private static Animator _animator;
    private static int _chestOpen;
    private static int _chestLocked;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _chestOpen = Animator.StringToHash("OpenChest");
        _chestLocked = Animator.StringToHash("LockedChest");
    }

    public static void LockedChest()
    {
        _animator.SetTrigger(_chestLocked);
    }

    public static void OpenChest()
    {
        _animator.SetBool(_chestOpen, true);
    }
}