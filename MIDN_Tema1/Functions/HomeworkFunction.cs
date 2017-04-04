using System;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class HomeworkFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Homework Function"; }
        }

        public override double CalculateValue(BitStringSolution solution)
        {
            double sum = 0;

            sum += Math.Pow(solution[0].ToDouble(), 3);

            sum += -60d*Math.Pow(solution[0].ToDouble(), 2);

            sum += 900*solution[0].ToDouble();

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

        public override double CalculateMaximizationValue(BitStringSolution solution)
        {
            return 100000 - CalculateValue(solution);
        }
    }
}