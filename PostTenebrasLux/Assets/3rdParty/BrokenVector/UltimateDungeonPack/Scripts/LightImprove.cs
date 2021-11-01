﻿using UnityEngine;

[ExecuteInEditMode]
public class LightImprove : MonoBehaviour
{
    public float setBias = -1f;

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Light>().shadowBias = setBias;
    }
}