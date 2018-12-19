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

            //GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject sph = Instantiate(OrbPrefab);
            sph.AddComponent<MeshRenderer>();

            parts = sph.GetComponentsInChildren<ParticleSystem>();
            Debug.Log(parts.Length);

            sph.transform.SetPositionAndRotation(pos, quat); ;
            sph.transform.parent = this.transform;
            sph.GetComponent<Renderer>().material.color = new Color(i + (float)MusicAnalyser.bands.Length, 1, 1);
            sph.AddComponent<SphereCollider>();
            sphs.Add(sph);
        }
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
            ts.z = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            sphs[i].transform.localScale = ts;*/
            foreach (ParticleSystem p in parts)
            {
                var main = p.main;
                //StartSize
                main.startSize = main.startSize;
                //ScaleParticleValues(p);
            }
            Vector3 OrbPos = sphs[i].transform.position;
            OrbPos.y = Mathf.Lerp(OrbPos.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime);
            sphs[i].transform.position = OrbPos;
        }
    }

    private void ScaleParticleValues(ParticleSystem ps)
    {
        //BASE MODULE
        var main = ps.main;
        //StartSize
        ParticleSystem.MinMaxCurve sSize = main.startSize;
        main.startSize = MultiplyMinMaxCurve(sSize, scale);
        //Gravity
        ParticleSystem.MinMaxCurve sGrav = main.gravityModifier;
        main.gravityModifier = MultiplyMinMaxCurve(sGrav, scale);
        //StartSpeed
        ParticleSystem.MinMaxCurve sSpeed = main.startSpeed;
        main.startSpeed = MultiplyMinMaxCurve(sSpeed, scale);
    }
    //Multiply or divide ParticleSystem.MinMaxCurve with given value
    private ParticleSystem.MinMaxCurve MultiplyMinMaxCurve(ParticleSystem.MinMaxCurve curve, float value, bool multiply = true)
    {
        if (multiply)
        {
            curve.curveMultiplier *= value;
            curve.constantMin *= value;
            curve.constantMax *= value;
        }
        else
        {
            curve.curveMultiplier /= value;
            curve.constantMin /= value;
            curve.constantMax /= value;
        }
        MultiplyCurveKeys(curve.curveMin, value, multiply);
        MultiplyCurveKeys(curve.curveMax, value, multiply);
        return curve;
    }

    //Multiply or divide all keys of an AnimationCurve with given value
    private void MultiplyCurveKeys(AnimationCurve curve, float value, bool multiply = true)
    {
        if (curve == null) { return; }
        if (multiply)
            for (int i = 0; i < curve.keys.Length; i++) { curve.keys[i].value *= value; }
        else
            for (int i = 0; i < curve.keys.Length; i++) { curve.keys[i].value /= value; }
    }
}
}
