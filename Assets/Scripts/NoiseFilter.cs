using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter {

    //Class for the noise filter which uses the open source Noise Script and multiplies the function by the AudioSampla
    Noise noise = new Noise();
    
    public float Evaluate(Vector3 point)
    {
        float noiseValue = (noise.Evaluate(point)+1) *(MusicAnalyser.bands[5] * 0.5f);
        return noiseValue;
    }
}
