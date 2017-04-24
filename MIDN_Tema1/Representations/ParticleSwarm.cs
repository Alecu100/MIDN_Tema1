using System.Collections.Generic;

namespace MIDN_Tema1.Representations
{
    public class ParticleSwarm
    {
        public List<Particle> Particles { get; } = new List<Particle>();

        public Particle GlobalMaximum { get; set; }
    }
}