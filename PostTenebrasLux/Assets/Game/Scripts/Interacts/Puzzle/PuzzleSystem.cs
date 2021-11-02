using UnityEngine;

/*
 * PuzzleSystem
 * Script to animate puzzle barrier opening once it is solved.
*/
public class PuzzleSystem : MonoBehaviour
{
    // puzzle system.
    public GameObject barrier;
    public Transform p, t, l;
    
    // animator and int for parameter trigger.
    private Animator _animator;
    private int _barrierOpen;

    // sound.
    public AudioClip barrierMovingSound;
    private bool _soundPlayed;

    private void Start()
    {
        _soundPlayed = false; // to set sound off.
        // set variables to Components and Parameters.
        _animator = barrier.GetComponent<Animator>();
        _barrierOpen = Animator.StringToHash("BarrierOpen");
    }

    private void Update()
    {
        // if all 3 puzzle pieces line up trigger animation to open barrier.
        if (p.eulerAngles.y == 90 && t.eulerAngles.y == 90 && l.eulerAngles.y == 90)
        {
            _animator.SetTrigger(_barrierOpen);
            // to prevent sound playing every frame.   
            if (_soundPlayed == false) 
            {
                AudioSource.PlayClipAtPoint(barrierMovingSound, transform.position);
                _soundPlayed = true;
            }
        }
    }
}