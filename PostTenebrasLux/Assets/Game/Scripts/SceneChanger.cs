using System.Collections;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // Animator and ints for animator boolean & SceneManager.
    private static Animator _animator;
    private static int _fadeOut;

    // Hash int to get animator trigger & get next scene.
    private void Start()
    {
        _fadeOut = Animator.StringToHash("FadeOut");
        _animator = GetComponent<Animator>();
    }

    // Set animation trigger to fade scene out.
    public static void FadeToScene()
    {
        _animator.SetTrigger(_fadeOut);
    }
}
