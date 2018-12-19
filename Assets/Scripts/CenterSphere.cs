using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSphere : MonoBehaviour {


    [Range(2, 256)]
    public int resolution = 10;

    public ShapeSetting shapesettings;
    public ColorSettings colorsettings;
    ShapeGenerator shapegenerator;

    [SerializeField, HideInInspector]
    MeshFilter[] meshfilters;
    SphereTerrain[] terrainFaces;

    private void OnValidate()
    {
        GenSphere();
    }

    void Initialise()
    {
        shapegenerator = new ShapeGenerator(shapesettings);
        if(meshfilters == null || meshfilters.Length == 0)
        {
            meshfilters = new MeshFilter[6];
        }
        terrainFaces = new SphereTerrain[6];

        Vector3[] directions = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        //6 sides of a cube (sphere) 
        for(int i =0; i< 6; i++)
        {
            if(meshfilters[i] ==null)
            {
                GameObject meshObj = new GameObject("mesh");//create a mesh
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshfilters[i] = meshObj.AddComponent<MeshFilter>();
                meshfilters[i].sharedMesh = new Mesh();
            }
            terrainFaces[i] = new SphereTerrain(shapegenerator, meshfilters[i].sharedMesh, resolution, directions[i]);

        }
    }

    private void Update()
    {
        Mesh m = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell3(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z);
        }
        m.vertices = vertices;
        m.RecalculateBounds();
        m.RecalculateNormals();
    }

    public static float SampleCell3(float x, float y)
    {
        float flatness = 0.2f;
        float noise = Mathf.PerlinNoise(10000 + x / 100, 10000 + y / 100);
        if (noise > 0.5f + flatness)
        {
            noise = noise - flatness;
        }
        else if (noise < 0.5f - flatness)
        {
            noise = noise + flatness;
        }
        else
        {
            noise = 0.5f;
        }

        return (noise * 300) + (Mathf.PerlinNoise(1000 + x / 5, 100 + y / 5) * 2);
    }

    public void GenSphere()
    {
        Initialise();
        GenMesh();
        //GenColor();
    }
    void GenMesh()
    {
        foreach(SphereTerrain face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
}
