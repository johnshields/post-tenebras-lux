using UnityEngine;
using UnityEngine.AI;

/*
 * PlayerProfiler.
 * Script that works with NavMesh to all the user to control the player character with a ClickToMove system.
 * Ref: https://youtu.be/7eAwVUsiqZU
*/
public class PlayerProfiler : MonoBehaviour
{
    // NavMesh variables.
    public LayerMask clickable;
    public GameObject targetDest; // x marks the spot...
    private NavMeshAgent _agent;
    private Camera _camera;

    // animator and bool parameter.
    private Animator _animator;
    private int _walkActive;

    private void Start()
    {
        // set variables
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _walkActive = Animator.StringToHash("WalkActive");
    }

    // Call functions required to move player character.
    private void Update()
    {
        ClickToMove();
        AnimationState();
    }

    // Player movement - User 'ClickToMove' system.
    private void ClickToMove()
    {
        // if user input is left click on location the player (agent) will move to that location. 
        if (Input.GetMouseButtonDown(0) && !PauseMenu.Paused)
        {
            // user's pointing ray
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            // allow user to cast a ray of where the player can move in the clickable areas (Layer Mask).
            if (!Physics.Raycast(ray, out var hit, 100, clickable)) return;
            _agent.SetDestination(hit.point);
            // update targetDest to the ray's hit point (Red X).
            targetDest.transform.position = hit.point;
        }
    }

    // Player animations - Transitions player's animations based on movement.
    private void AnimationState()
    {
        // if player (agent) is moving set animation state to walk else revert to idle. 
        if (_agent.velocity != Vector3.zero) 
            _animator.SetBool(_walkActive, true);
        else if (_agent.velocity == Vector3.zero) 
            _animator.SetBool(_walkActive, false);
    }
}