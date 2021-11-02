using UnityEngine;

/*
 * Key
 * Script to animate key jumping out of chest. (Called in Interacts)
*/
public class Key : MonoBehaviour
{
    // animator and int for parameter trigger.
    private static Animator _animator;
    private static int _jumpKey;

    private void Start()
    {
        // set variables to Components and Parameters.
        _animator = GetComponent<Animator>();
        _jumpKey = Animator.StringToHash("JumpKey");
    }

    // Animate key jumping out of chest.
    public static void KeyJump()
    {
        _animator.SetTrigger(_jumpKey);
    }
}