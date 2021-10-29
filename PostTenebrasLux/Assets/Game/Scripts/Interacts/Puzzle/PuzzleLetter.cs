using System;
using UnityEngine;

public class PuzzleLetter : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.Rotate(0, 90, 0);
    }
}
