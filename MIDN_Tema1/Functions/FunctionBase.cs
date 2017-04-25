using System;
using System.Collections.Generic;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public abstract class FunctionBase : IFunction
    {
        public int NumberOfBits
        {
            get { return (int) Math.Ceiling(Math.Log(NumberOfIntervals, 2)); }
        }

        public abstract double CalculateMaximizationValue(List<double> solution);

        public int NumberOfIntervals { get; set; }

        public abstract double CalculateValue(List<double> solution);


        public abstract BitStringSolution GetRandomSolution(int numberOfInputs);

        public abstract Particle GetRandomParticle(int numberOfInputs);

        public abstract string Name { get; }

        public bool IsBetterThanCurrentValue(double currentValue, double newValue)
        {
            return currentValue > newValue;
        }

        protected BitStringSolution GetRandomSolution(int numberOfInputs, double lowerLimit, double upperLimit)
        {
            var bitStringSolution = new BitStringSolution();

            for (var i = 0; i < numberOfInputs; i++)
            {
                var randomBitStringNumber = GetRandomBitStringNumber(lowerLimit, upperLimit);

                bitStringSolution.Add(randomBitStringNumber);
            }

            return bitStringSolution;
        }

        protected ParticleDimension GetRandomParticleDimension(double lowerLimit,
            double upperLimit)
        {
            var next4Digits = RandomUtils.GetNext4Digits();

            var random = new Random(next4Digits);

            var lowerLimitDecimal = (decimal) lowerLimit;
            var upperLimitDecimal = (decimal) upperLimit;
            var ratio = (decimal) random.NextDouble();

            var particleDimension = new ParticleDimension();

            particleDimension.Value = (double) ((lowerLimitDecimal*ratio + upperLimitDecimal*(1 - ratio))/2);
            particleDimension.LowerLimit = lowerLimit;
            particleDimension.UpperLimit = upperLimit;

            return particleDimension;
        }

        protected Particle GetRandomParticle(int numberOfInputs, double lowerLimit,
            double upperLimit)
        {
            var particle = new Particle();

            for (var i = 0; i < numberOfInputs; i++)
            {
                particle.Add(GetRandomParticleDimension(lowerLimit, upperLimit));
            }

            return particle;
        }

        protected BitStringNumber GetRandomBitStringNumber(double lowerLimit, double upperLimit)
        {
            var bitStringNumber = new BitStringNumber();

            for (var i = 0; i < NumberOfBits; i++)
            {
                var random2 =
                    new Random(RandomUtils.GetNext4Digits());

                if (random2.NextDouble() >= 0.5)
                    bitStringNumber.Add(1);
                else
                    bitStringNumber.Add(0);
            }

            bitStringNumber.LowerLimit = lowerLimit;
            bitStringNumber.UpperLimit = upperLimit;
            bitStringNumber.NumberOfIntervals = NumberOfIntervals;

            return bitStringNumber;
        }
    }
}