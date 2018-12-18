using UnityEngine;

public class TerraineGen : MonoBehaviour {
    public int width = 256;
    public int height = 256;//length
    public int depth = 20;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        //random numbers for offsets
        offsetX = Random.RandomRange(0f, 9999f);
        offsetY = Random.RandomRange(0f, 9999f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);//terrain data = newly generated terrain based off current terrain data

        offsetX += Time.deltaTime;//update offset to make terrain move
    }

    TerrainData GenerateTerrain(TerrainData terrrainData)//returns terrain data
    {
        terrrainData.heightmapResolution = width + 1;
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
        //take coordinates and convert them to noise map coordinates
        float x = (float)i / width * scale + offsetX;
        float y = (float)j / height * scale + offsetY;

        return Mathf.PerlinNoise(x, y);//return value of the perlin noise function at those coordinates and set them into the array
    }

}

