using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SineWave 
{

    public static float Calculate(float max_value, float b, float x) 
    {
        return (float) max_value * Mathf.Sin(b * x);
    } 
}
