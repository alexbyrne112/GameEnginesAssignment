using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour {

    public float radius = 30;
    public int numDestinations = 8;
    List<Vector3> destinations = new List<Vector3>();
    public float speed = 5;
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
