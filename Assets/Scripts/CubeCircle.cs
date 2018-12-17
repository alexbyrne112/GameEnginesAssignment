using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCircle : MonoBehaviour {
    public float scale = 10;
    List<GameObject> cyls = new List<GameObject>();
    public float radius = 100;

	// Use this for initialization
	void Start () {
        CreateCubeCircle();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateCubeCircle()
    {
        float theta = (Mathf.PI * 2.0f) / (float)MusicAnalyser.bands.Length;
        for(int i = 0; i < MusicAnalyser.bands.Length; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            pos = transform.TransformPoint(pos);
            Quaternion quat = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            quat = transform.rotation * quat;

            GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cyl.transform.SetPositionAndRotation(pos, quat); ;
            cyl.transform.parent = this.transform;
            cyl.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)MusicAnalyser.bands.Length, 1, 1);
            cyls.Add(cyl);
        }
    }
}
