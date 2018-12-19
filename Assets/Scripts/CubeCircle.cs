using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCircle : MonoBehaviour {
    public float scale = 10;
    List<GameObject> sphs = new List<GameObject>();
    GameObject sphere;
    public float radius = 1;
    public GameObject OrbPrefab;

    ParticleSystem[] parts;

    // Use this for initialization
    void Start () {
        CreateCubeCircle();
        CreateSphere();
    }

    void CreateCubeCircle()
    {
        float theta = (Mathf.PI * 2.0f) / (float)MusicAnalyser.bands.Length;
        for (int i = 0; i < MusicAnalyser.bands.Length; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * 30, 0, Mathf.Cos(theta * i) * 30);
            pos = transform.TransformPoint(pos);
            Quaternion quat = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            quat = transform.rotation * quat;

            //GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject sph = Instantiate(OrbPrefab);
            sph.AddComponent<MeshRenderer>();
            sph.transform.SetPositionAndRotation(pos, quat); ;
            sph.transform.parent = this.transform;
            //sph.GetComponent<Renderer>().material.color = new Color(i + (float)MusicAnalyser.bands.Length, 1, 1);
            //sph.AddComponent<SphereCollider>();
            sphs.Add(sph);
        }
    }

    void CreateSphere()
    {
        Vector3 Spos = new Vector3(0, 0, 0);
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = Spos;
        sphere.transform.parent = this.transform;
        sphere.transform.localScale = new Vector3(10,10,10);
        sphere.GetComponent<Renderer>().material.color = new Color((float)MusicAnalyser.bands.Length, 1, 1);
    }


    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime*20);
        for (int i = 0; i < sphs.Count; i++)
        {
            /*
            Vector3 ts = sphs[i].transform.localScale;
            ts.y = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            ts.x = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            ts.z = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);m              (MusicAnalyser.bands[i]* 2)
            sphs[i].transform.localScale = ts;*/
            parts = sphs[i].GetComponentsInChildren<ParticleSystem>();
            Debug.Log(parts.Length);
            for (int s =0; s < parts.Length; s++) 
            {
                ParticleSystem p = parts[s];
                var SOL = p.sizeOverLifetime;
                SOL.enabled = true;
                
                AnimationCurve curve = new AnimationCurve();
                curve.AddKey(0.0f, 0.0f);
                curve.AddKey(1.0f, 1.0f);

                SOL.size = new ParticleSystem.MinMaxCurve(1 + MusicAnalyser.bands[i], 1);
                //ScaleParticleValues(p);
            }
            
            /*Vector3 OrbPos = sphs[i].transform.position;
            OrbPos.y = Mathf.Lerp(OrbPos.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime);
            sphs[i].transform.position = OrbPos;*/
        }
    }
}
