using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete("Does not work", true)]
public class DetachTrail : MonoBehaviour, IOnObjectDestroyed {
    public void OnObjectDestroyed() {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        int count = particleSystem.particleCount;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[count];
        particleSystem.GetParticles(particles);
        
    }
}
