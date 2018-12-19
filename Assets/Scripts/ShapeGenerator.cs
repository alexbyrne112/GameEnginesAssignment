using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator{
    ShapeSetting settings;
    NoiseFilter noiseFilter;

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
