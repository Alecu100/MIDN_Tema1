using System;
using System.Collections.Generic;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class HomeworkFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Homework Function"; }
        }

        public override Particle GetRandomParticle(int numberOfInputs)
        {
            return GetRandomParticle(numberOfInputs, 0, 31);
        }

        public override double CalculateValue(List<double> solution)
        {
            double sum = 0;

            sum += Math.Pow(solution[0], 3);

            sum += -60d*Math.Pow(solution[0], 2);

            sum += 900*solution[0];

            sum += 100;

            return 20000 - sum;
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            var bitStringSolution = new BitStringSolution();

            var randomBitStringNumber = GetRandomBitStringNumber(0, 31);

            bitStringSolution.Add(randomBitStringNumber);

            return bitStringSolution;
        }

        public override double CalculateMaximizationValue(List<double> solution)
        {
            return 100000 - CalculateValue(solution);
        }
    }
}