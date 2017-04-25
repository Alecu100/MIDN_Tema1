using System.Collections.Generic;

namespace MIDN_Tema1.Representations
{
    public class ParticleSwarm : List<Particle>
    {
        public Particle GlobalMaximum { get; set; }
    }
}