using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts
{
    public class PlayerProfiler : MonoBehaviour
    {
        public LayerMask clickable;
        private NavMeshAgent _agent;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _agent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            ClickToMove();
        }
        
        // Player movement
        private void ClickToMove()
        {
            // if user input is left click on location the player (agent) will move to that location. 
            if (Input.GetMouseButtonDown(0))
            {
                // user's pointing ray
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                // allow user to cast a ray of where the player can move in the clickable areas (Layer Mask).
                if (Physics.Raycast(ray, out var hitInfo, 100, clickable))
                {
                    _agent.SetDestination(hitInfo.point);
                }
            }
        }
    }
}
