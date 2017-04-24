using System;
using System.Collections.Generic;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class GriewangkFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Griewangk"; }
        }

        public override double CalculateValue(List<double> numbers)
        {
            double sum = 0;
            double prod = 1;

            for (var i = 0; i < numbers.Count; i++)
            {
                var numberDouble = numbers[i];
                sum += numberDouble * numberDouble / 4000d;
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                var numberDouble = numbers[i];

                prod *= Math.Cos(numberDouble / Math.Sqrt(i + 1));
            }

            sum -= prod;
            sum += 1;

            return sum;
        }

        public override double CalculateMaximizationValue(List<double> solution)
        {
            return 300 - CalculateValue(solution);
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            return GetRandomSolution(numberOfInputs, -600d, 600d);
        }
    }
}