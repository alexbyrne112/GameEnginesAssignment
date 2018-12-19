using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator{
    ShapeSetting settings;

    public ShapeGenerator(ShapeSetting settings)
    {
        this.settings = settings;
    }

    public Vector3 calcPoint(Vector3 pointOnSphere)
    {
        return pointOnSphere * settings.SphereRadius;
    }
}
