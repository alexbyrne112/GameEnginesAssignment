﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicAnalyser : MonoBehaviour {

    AudioSource audio;
    public static int frameSize = 512;
    public static float[] samples = new float[512];
    public static float[] bands;
    private AudioClip clip;
    private AudioMixerGroup amgMaster;
    public float binWidth;
    public float sampleRate;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        samples = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize, 2)];


        audio.clip = clip;
        audio.outputAudioMixerGroup = amgMaster;
        audio.Play();
    }

    // Use this for initialization
    void Start () {
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;
    }
	
	// Update is called once per frame
	void Update () {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        GetBands();
    }

    void GetBands()
    {
   
    }
}
