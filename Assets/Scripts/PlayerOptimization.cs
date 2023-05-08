using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerOptimization : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        print(Time.frameCount / Time.time);
    }
}
