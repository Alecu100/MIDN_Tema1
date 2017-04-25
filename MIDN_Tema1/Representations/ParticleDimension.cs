namespace MIDN_Tema1.Representations
{
    public class ParticleDimension
    {
        public double Value { get; set; }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public double Velocity { get; set; }

        public ParticleDimension Copy()
        {
            var particleDimension = new ParticleDimension();

            particleDimension.Value = Value;
            particleDimension.LowerLimit = LowerLimit;
            particleDimension.UpperLimit = UpperLimit;
            particleDimension.Velocity = Velocity;

            return particleDimension;
        }
    }
}