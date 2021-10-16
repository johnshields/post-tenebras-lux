using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Key found!");
    }
}
