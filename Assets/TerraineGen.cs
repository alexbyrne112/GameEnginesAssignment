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

    TerrainData GenerateTerrain(TerrainData terrrainData)//returns terrain data
    {
        terrrainData.size = new Vector3(width, depth, height);//populate dimensions
        terrrainData.SetHeights(0, 0, genHeights());

        return terrrainData;
    }

    float[,] genHeights()
    {
        float[,] heights = new float[width, height];//each point has a float set to it (grid)
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] = calcHeight(i, j);//perlin noise function 
            }
        }
        return heights;
    }

    //calculate height at x and y position
    float calcHeight(int i, int j)
    {

    }
}

