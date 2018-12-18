using UnityEngine;

public class TerraineGen : MonoBehaviour {
    public int width = 256;
    public int height = 256;//length
    public int depth = 20;

    public float scale = 20f;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);//terrain data = newly generated terrain based off current terrain data
    }

    TerrainData GenerateTerrain()
    {

    }
}

