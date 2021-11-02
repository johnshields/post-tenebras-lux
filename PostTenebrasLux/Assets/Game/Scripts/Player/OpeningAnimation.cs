using System.Collections;
using UnityEngine;

/*
 * OpeningAnimation
 * Script to have player character stand up when scene starts.
*/
public class OpeningAnimation : MonoBehaviour
{
    public GameObject inventoryMenu;
    private GameObject _player;
    private Animator _animator;
    private int _standUp, _idleActive;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _standUp = Animator.StringToHash("StandActive");
        _idleActive = Animator.StringToHash("IdleActive");
        _player = GameObject.Find("Player");

        // play stand up animation on start, then call GoToIdle to transition to idle.
        _player.GetComponent<PlayerProfiler>().enabled = false;
        _animator.SetBool(_standUp, true);
        StartCoroutine(GoToIdle());
    }

    // IEnumerator to transition to idle after standUp Animation is complete (10ish seconds).
    private IEnumerator GoToIdle()
    {
        yield return new WaitForSeconds(10.8f);
        _animator.SetBool(_standUp, false);
        _animator.SetBool(_idleActive, true);
        _player.GetComponent<PlayerProfiler>().enabled = true; // enable player controls
        inventoryMenu.SetActive(true); // enable Inventory Menu
    }
}