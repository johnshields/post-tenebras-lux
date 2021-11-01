using UnityEngine;

public class PuzzleSystem : MonoBehaviour
{
    public GameObject barrier;
    public Transform p, t, l;
    private Animator _animator;
    private int _barrierOpen;

    private void Start()
    {
        _animator = barrier.GetComponent<Animator>();
        _barrierOpen = Animator.StringToHash("BarrierOpen");
    }

    private void Update()
    {
        if (p.eulerAngles.y == 90 && t.eulerAngles.y == 90 && l.eulerAngles.y == 90)
            _animator.SetTrigger(_barrierOpen);
    }
}