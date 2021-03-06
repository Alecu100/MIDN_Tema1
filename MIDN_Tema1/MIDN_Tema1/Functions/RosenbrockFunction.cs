﻿using System;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public class RosenbrockFunction : FunctionBase
    {
        public override string Name
        {
            get { return "Rosenbrock"; }
        }

        public override double CalculateValue(BitStringSolution numbers)
        {
            double sum = 0;

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var currentNumberDouble = numbers[i].ToDouble();
                var nextNumberDouble = numbers[i + 1].ToDouble();

                sum += 100*Math.Pow(nextNumberDouble - currentNumberDouble*currentNumberDouble, 2) +
                       Math.Pow(1 - currentNumberDouble, 2);
            }

            return sum;
        }

        public override BitStringSolution GetRandomSolution(int numberOfInputs)
        {
            return GetRandomSolution(numberOfInputs, -2.048d, 2.048d);
        }
    }
}