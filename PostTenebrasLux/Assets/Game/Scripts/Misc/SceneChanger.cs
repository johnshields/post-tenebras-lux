using UnityEngine;

/*
 * SceneChanger
 * Script to animate scene fading out.
*/
public class SceneChanger : MonoBehaviour
{
    // Animator and ints for animator boolean.
    private static Animator _animator;
    private static int _fadeOut;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        // Hash int to get animator trigger
        _fadeOut = Animator.StringToHash("FadeOut");
    }

    // Set animation trigger to fade scene out.
    public static void FadeToScene()
    {
        _animator.SetTrigger(_fadeOut);
    }
}
