using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Door locked!");
    }
}
