using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTerrain{

    ShapeGenerator shapeGenerator;
    Mesh mesh;
    int resolution;
    Vector3 locUp;
    Vector3 AxisA;
    Vector3 AxisB;

    public SphereTerrain(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 locUp)
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.resolution = resolution;
        this.locUp = locUp;

        AxisA = new Vector3(locUp.y, locUp.z, locUp.x);
        AxisB = Vector3.Cross(locUp, AxisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triIndex = 0;
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                int vertex = i + j * resolution;

                float noise = Mathf.PerlinNoise(i, j);

                Vector2 percent = new Vector2(i, j) / (resolution - 1);//used to define where each vertex should be on the face
                Vector3 PointOnCube = locUp + (percent.x - 0.5f) * 2 * AxisA + (percent.y - 0.5f) * 2 * AxisB;//shape of meshes
                Vector3 pointOnSphere = PointOnCube.normalized;//make all triangles same distance from center
                //vertices[vertex] = pointOnSphere;//vertex on the sphere
                vertices[vertex] = shapeGenerator.calcPoint(pointOnSphere);

                if (j != resolution - 1 && i != resolution - 1)
                {
                    //creating first triangle
                    triangles[triIndex] = vertex;
                    triangles[triIndex + 1] = vertex + resolution + 1;
                    triangles[triIndex + 2] = vertex + resolution;

                    //second triangle
                    triangles[triIndex + 3] = vertex;
                    triangles[triIndex + 4] = vertex + 1;
                    triangles[triIndex + 5] = vertex + resolution + 1;
                    triIndex += 6;//becaise 6 vertices used
                }
            }
        }
        mesh.Clear(); //for different resolutions error
        //assign calculations to mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();// and normalise it
    }
}
