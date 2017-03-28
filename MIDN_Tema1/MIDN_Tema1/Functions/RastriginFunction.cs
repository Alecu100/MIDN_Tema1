using System;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class RastriginFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Rastrigin"; }
        }

        public override double CalculateValue(BitStringSolution numbers)
        {
            double sum = numbers.Count*10;

            for (var i = 0; i < numbers.Count; i++)
            {
                var numberDouble = numbers[i].ToDouble();

                sum += numberDouble*numberDouble - 10*Math.Cos(2*Math.PI*numberDouble);
            }

            return sum;
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            return GetRandomSolution(numberOfInputs, -5.12d, 5.12d);
        }
    }
}