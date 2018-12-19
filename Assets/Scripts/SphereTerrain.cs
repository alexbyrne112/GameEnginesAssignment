using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTerrain {

    Mesh mesh;
    int resolution;
    Vector3 locUp;
    Vector3 AxisA;
    Vector3 AxisB;

    public SphereTerrain(Mesh mesh, int resolution, Vector3 locUp)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.locUp = locUp;

        AxisA = new Vector3(locUp.y, locUp.z, locUp.x);
        AxisB = Vector3.Cross(locUp, AxisA);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
