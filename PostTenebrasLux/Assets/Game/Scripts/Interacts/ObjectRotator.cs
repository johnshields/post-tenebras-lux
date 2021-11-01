using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(1f, 1f, 1f));
    }
}