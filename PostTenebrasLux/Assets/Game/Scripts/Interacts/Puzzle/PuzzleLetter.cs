using UnityEngine;

/*
 * PuzzleLetter
 * Script to have puzzle letters rotate 90 degrees (Y Axis) with mouse interaction.
*/
public class PuzzleLetter : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.Rotate(0, 90, 0);
    }
}