using System;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class SixHumpCamelBack : FunctionBase
    {
        public override string Name
        {
            get { return "Six-hump camel back"; }
        }

        public override double CalculateValue(BitStringSolution solution)
        {
            double sum = 0;
            var first = solution[0].ToDouble();
            var second = solution[1].ToDouble();


            sum += (4 - 2.1d*Math.Pow(first, 2) + Math.Pow(first, 4d/3d))*Math.Pow(first, 2);

            sum += first*second;

            sum += (-4d + 4d*Math.Pow(second, 2))*Math.Pow(second, 2);

            return sum;
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            var bitStringSolution = new BitStringSolution();

            bitStringSolution.Add(GetRandomBitStringNumber(-3d, 3d, 1, 5));
            bitStringSolution.Add(GetRandomBitStringNumber(-2d, 2d, 3, 666));

            return bitStringSolution;
        }
    }
}