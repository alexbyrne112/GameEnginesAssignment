using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicAnalyser : MonoBehaviour {

    AudioSource audio;
    public float[] samples = new float[512];

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrum();
	}

    void GetSpectrum()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
