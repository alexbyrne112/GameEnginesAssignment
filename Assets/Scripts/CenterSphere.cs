using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSphere : MonoBehaviour {


    [Range(2, 256)]
    public int resolution = 10;
    
    public ShapeSetting shapesettings;
    ShapeGenerator shapegenerator;

    [SerializeField, HideInInspector]
    MeshFilter[] meshfilters;
    SphereTerrain[] terrainFaces;

    private void OnValidate()
    {
        //GenSphere();
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
        GenSphere();
    }
  

    public void GenSphere()
    {
        Initialise();
        GenMesh();
    }
    void GenMesh()
    {
        foreach(SphereTerrain face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
}
