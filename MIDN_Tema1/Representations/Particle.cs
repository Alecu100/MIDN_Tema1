using System.Collections.Generic;

namespace MIDN_Tema1.Representations
{
    public class Particle : List<ParticleDimension>
    {
        public Particle Maximum { get; set; }

        public Particle Copy()
        {
            var particle = new Particle();

            for (var i = 0; i < Count; i++)
            {
                particle.Add(this[i].Copy());
            }

            return particle;
        }

        public List<double> ToDouble()
        {
            var doubles = new List<double>();

            for (var i = 0; i < Count; i++)
            {
                doubles.Add(this[i].Value);
            }

            return doubles;
        }
    }
}