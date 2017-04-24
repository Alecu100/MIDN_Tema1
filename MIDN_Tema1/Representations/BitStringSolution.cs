using System;
using System.Collections.Generic;

namespace MIDN_Tema1.Representations
{
    [Serializable]
    public class BitStringSolution : List<BitStringNumber>
    {
        public BitStringSolution Copy()
        {
            var copy = new BitStringSolution();

            for (var i = 0; i < Count; i++)
            {
                var numberCopy = new BitStringNumber();
                var currentNumber = this[i];


                for (var j = 0; j < currentNumber.Count; j++)
                    numberCopy.Add(currentNumber[j]);

                numberCopy.LowerLimit = currentNumber.LowerLimit;
                numberCopy.UpperLimit = currentNumber.UpperLimit;
                numberCopy.NumberOfIntervals = currentNumber.NumberOfIntervals;

                copy.Add(numberCopy);
            }

            return copy;
        }

        public List<double> ToDouble()
        {
            var doubles = new List<double>();

            for (var i = 0; i < Count; i++)
                doubles.Add(this[i].ToDouble());

            return doubles;
        }
    }
}