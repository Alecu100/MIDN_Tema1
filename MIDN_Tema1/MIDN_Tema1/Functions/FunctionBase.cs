﻿using System;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public abstract class FunctionBase : IFunction
    {
        public int NumberOfBits
        {
            get { return (int) Math.Ceiling(Math.Log(NumberOfIntervals, 2)); }
        }

        public int NumberOfIntervals { get; set; }

        public abstract double CalculateValue(BitStringSolution solution);

        public abstract BitStringSolution GetRandomSolution(int numberOfInputs);
        public abstract string Name { get; }

        public bool IsBetterThanCurrentValue(double currentValue, double newValue)
        {
            return currentValue > newValue;
        }

        protected BitStringSolution GetRandomSolution(int numberOfInputs, double lowerLimit, double upperLimit)
        {
            var bitStringSolution = new BitStringSolution();
            var ticks = (int) (DateTime.Now.Ticks%100000);

            for (var i = 0; i < numberOfInputs; i++)
            {
                var randomBitStringNumber = GetRandomBitStringNumber(lowerLimit, upperLimit, i, ticks);

                bitStringSolution.Add(randomBitStringNumber);
            }

            return bitStringSolution;
        }

        protected BitStringNumber GetRandomBitStringNumber(double lowerLimit, double upperLimit, int randomFactor,
            int randomFactor2)
        {
            var bitStringNumber = new BitStringNumber();
            var random = new Random();

            for (var i = 0; i < NumberOfBits; i++)
            {
                var random2 =
                    new Random(random.Next(0, int.MaxValue - randomFactor - 1 - randomFactor2) + randomFactor +
                               randomFactor2);

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