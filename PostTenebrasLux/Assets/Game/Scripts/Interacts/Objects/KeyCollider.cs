using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    private static Animator _animator;
    private static int _jumpKey;
    private static int _backJump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jumpKey = Animator.StringToHash("JumpKey");
        _backJump = Animator.StringToHash("BackJump");
    }

    public static void KeyJump()
    {
        _animator.SetTrigger(_jumpKey);
    }
    
    public static void BackJump()
    {
        _animator.SetTrigger(_backJump);
    }
}
