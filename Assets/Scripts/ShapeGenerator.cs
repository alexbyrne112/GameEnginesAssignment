using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Generating the Sphere with the points Vertices calculated
public class ShapeGenerator{
    ShapeSetting settings;
    NoiseFilter noiseFilter;
    //Constructor
    public ShapeGenerator(ShapeSetting settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter();
    }

    public Vector3 calcPoint(Vector3 pointOnSphere)
    {
        float elevation = noiseFilter.Evaluate(pointOnSphere);
        return pointOnSphere * settings.SphereRadius * (1+elevation);
    }
}
