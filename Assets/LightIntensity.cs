using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    Light lt;
	// Use this for initialization
	void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float intense = (MusicAnalyser.bands[5]) * 2500;
        lt.intensity = intense;
        Debug.Log(intense);
	}
}
