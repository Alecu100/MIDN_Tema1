using System;
using System.Collections.Generic;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class RastriginFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Rastrigin"; }
        }

        public override Particle GetRandomParticle(int numberOfInputs)
        {
            return GetRandomParticle(numberOfInputs, -5.12d, 5.12d);
        }

        public override double CalculateValue(List<double> numbers)
        {
            double sum = numbers.Count*10;

            for (var i = 0; i < numbers.Count; i++)
            {
                var numberDouble = numbers[i];

                sum += numberDouble*numberDouble - 10*Math.Cos(2*Math.PI*numberDouble);
            }

            return sum;
        }

        public override double CalculateMaximizationValue(List<double> solution)
        {
            return 300 - CalculateValue(solution);
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            return GetRandomSolution(numberOfInputs, -5.12d, 5.12d);
        }
    }
}