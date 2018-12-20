using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCircle : MonoBehaviour {
    public float scale = 10;
    List<GameObject> sphs = new List<GameObject>();
    public float radius = 1;
    public GameObject OrbPrefab;

    ParticleSystem[] parts;

    // Use this for initialization
    void Start () {
        CreateCubeCircle();
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
            
            GameObject sph = Instantiate(OrbPrefab);
            sph.AddComponent<MeshRenderer>();
            sph.transform.SetPositionAndRotation(pos, quat); ;
            sph.transform.parent = this.transform;
            sphs.Add(sph);
        }
    }


    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime*20);

        for (int i = 0; i < sphs.Count; i++)
        {
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
            }
            //Lerps orbs up and down on the Y axis
            Vector3 OrbPos = sphs[i].transform.position;
            OrbPos.y = Mathf.Lerp(OrbPos.y, 1 + (MusicAnalyser.bands[i] * scale)*2, Time.deltaTime);
            sphs[i].transform.position = OrbPos;
        }
    }
}
