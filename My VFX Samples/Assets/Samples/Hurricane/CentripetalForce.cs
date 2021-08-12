using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentripetalForce : MonoBehaviour
{
    private ParticleSystem.Particle[] m_Particles;
    private ParticleSystem m_System;
    //public Transform target
    private Vector3 targetDir;

    // Start is called before the first frame update
    void Start()
    {
        m_System = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
        //target = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int numParticlesAlive = m_System.GetParticles(m_Particles);
 
        for (int i = 0; i < numParticlesAlive; i++)
        {
            var target = new Vector3(0, m_Particles[i].position.y, 0);
            targetDir = target - m_Particles[i].position;
            //print(m_Particles[i].position);
//            m_Particles[i].position = target;
            //m_Particles[i].velocity = Vector3.up;
            //targetDir = -(new Vector3(m_Particles[i].position.x, 0, m_Particles[i].position.z));
            //targetDir = new Vector3(m_Particles[i].position.x, m_Particles[i].position.y, m_Particles[i].position.z);

           // m_Particles[i].velocity += gravity * Time.fixedDeltaTime;
           float mass = 1f;
           var force = mass * Mathf.Pow(m_Particles[i].velocity.magnitude, 2) / targetDir.magnitude;
           //m_Particles[i].velocity += m_Particles[i] force * Time.fixedDeltaTime;
           m_Particles[i].velocity += targetDir * force * Time.fixedDeltaTime;
        }
 
         m_System.SetParticles(m_Particles, numParticlesAlive);
    }
}
