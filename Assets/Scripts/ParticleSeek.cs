using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSeek : MonoBehaviour {
    public Transform target;
    public float force = 100.0f;
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        ps.GetParticles(particles);
        for (int i = 0; i < particles.Length; i++)
        {
            ParticleSystem.Particle p = particles[i];//reference of particle
            Vector3 particleWorldPos;
            if(ps.main.simulationSpace == ParticleSystemSimulationSpace.Local)//for different positions relitive to the World/Local/Custom Space
            {
                particleWorldPos = transform.TransformPoint(p.position);
            }
            else if(ps.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
            {
                particleWorldPos = ps.main.customSimulationSpace.transform.TransformPoint(p.position);
            }
            else
            {
                particleWorldPos = p.position;
            }
            Vector3 targetDirection = (target.position - particleWorldPos).normalized; //normalised to stop it adding extra force to the particle
            Vector3 seekforce = targetDirection * force * Time.deltaTime;
            p.velocity += seekforce;
            particles[i] = p;//update back into array;
        }
        ps.SetParticles(particles, particles.Length);//add all particles back into Particle System
    }
}
