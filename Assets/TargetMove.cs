using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {

    public float radius = 30;
    public int numDestinations = 8;
    List<Vector3> destinations = new List<Vector3>();
    public float speed = 5;
    public Transform target;
    public int current = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        float ThetaInc = (Mathf.PI * 2) / numDestinations;
        for(int i = 0; i < numDestinations; i++)
        {
            float theta = i * ThetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            destinations.Add(pos);
        }
    }
}
