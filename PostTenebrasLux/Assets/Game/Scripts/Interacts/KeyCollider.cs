using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    private static Animator _animator;
    private static int _jumpKey;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jumpKey = Animator.StringToHash("JumpKey");
    }

    public static void KeyJump()
    {
        _animator.SetTrigger(_jumpKey);
    }
}