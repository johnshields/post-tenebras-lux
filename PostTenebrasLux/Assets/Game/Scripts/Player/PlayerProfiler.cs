using UnityEngine;
using UnityEngine.AI;

public class PlayerProfiler : MonoBehaviour
{
    public LayerMask clickable;
    public GameObject targetDest;
    private NavMeshAgent _agent;

    private Animator _animator;
    private Camera _camera;
    private int _walkActive;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _walkActive = Animator.StringToHash("WalkActive");
        PlayerInventory.DoorKey = 1;
    }

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
            // update targetDest to the ray's hit point (Green Circle).
            targetDest.transform.position = hit.point;
        }
    }

    // Player animations - Transitions player's animations based on movement.
    private void AnimationState()
    {
        // if player (agent) is moving set animation state to walk else revert to idle. 
        if (_agent.velocity != Vector3.zero) _animator.SetBool(_walkActive, true);
        else if (_agent.velocity == Vector3.zero) _animator.SetBool(_walkActive, false);
    }
}