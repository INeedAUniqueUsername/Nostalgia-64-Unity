using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachTrail : MonoBehaviour, IOnObjectDestroyed {
    public void OnObjectDestroyed() {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        int count = particleSystem.particleCount;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[count];
        particleSystem.GetParticles(particles);
        
    }
}
