using UnityEngine;

public class PuzzleSystem : MonoBehaviour
{
    public GameObject p, t, l, barrier;

    private void Update()
    {
        var pAngle = p.transform.eulerAngles;
        var tAngle = t.transform.eulerAngles;
        var lAngle = l.transform.eulerAngles;
        
        if (pAngle.y == 90 && tAngle.y == 90 && lAngle.y == 90) 
            Destroy(barrier);
    }
}
