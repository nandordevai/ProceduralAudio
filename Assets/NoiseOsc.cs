﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseOsc : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float offset;
    
    System.Random rand = new System.Random();
    
    void OnAudioFilterRead(float[] data, int channels) {
        for (int i = 0; i < data.Length; i++) {
            data[i] = (float)(rand.NextDouble() * 2.0 - 1.0 + offset);
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
