using UnityEngine;

/*
 * KeyCollider
 * Script to animate key collider jumping out of chest. (Called in Interacts)
*/
public class KeyCollider : MonoBehaviour
{
    // animator and ints for parameter trigger.
    private static Animator _animator;
    private static int _jumpKey;
    private static int _backJump;

    private void Start()
    {
        // set variables to Components and Parameters.
        _animator = GetComponent<Animator>();
        _jumpKey = Animator.StringToHash("JumpKey");
        _backJump = Animator.StringToHash("BackJump");
    }

    // Animate key collider jumping out of chest.
    public static void KeyJump()
    {
        _animator.SetTrigger(_jumpKey);
    }

    // Have key collider animate jump back in chest to avoid further collisions. 
    public static void BackJump()
    {
        _animator.SetTrigger(_backJump);
    }
}