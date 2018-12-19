using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSphere : MonoBehaviour {


    [Range(2, 256)]
    public int resolution = 10;

    public ShapeSetting shapesetting;
    public ColorSettings colorsetting;

    [SerializeField, HideInInspector]
    MeshFilter[] meshfilters;
    SphereTerrain[] terrainFaces;

    private void OnValidate()
    {
        Initialise();
        GenMesh();
    }

    void Initialise()
    {
        if(meshfilters == null || meshfilters.Length == 0)
        {
            meshfilters = new MeshFilter[6];
        }
        terrainFaces = new SphereTerrain[6];

        Vector3[] directions = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for(int i =0; i< 6; i++)
        {
            if(meshfilters[i] ==null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;
                meshObj.transform.localScale = new Vector3(10, 10, 10);

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshfilters[i] = meshObj.AddComponent<MeshFilter>();
                meshfilters[i].sharedMesh = new Mesh();
            }
            terrainFaces[i] = new SphereTerrain(meshfilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenMesh()
    {
        foreach(SphereTerrain face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    void GenColor()
    {
        foreach (MeshFilter m in meshfilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = new Color(255, 0, 255, 255);
        }
    }
}
