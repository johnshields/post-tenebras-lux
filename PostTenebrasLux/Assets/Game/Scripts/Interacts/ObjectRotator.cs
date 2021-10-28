using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(1f, 2f, 2f));
    }
}
