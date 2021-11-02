using UnityEngine;

/*
 * ObjectRotator
 * Script to rotate objects (keys + scrolls).
*/
public class ObjectRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(1f, 1f, 1f));
    }
}