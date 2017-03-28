using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MIDN_Tema1.Representations
{
    [Serializable]
    public class BitStringSolution : List<BitStringNumber>
    {
        public BitStringSolution Copy()
        {
            var copy = new BitStringSolution();

            for (int i = 0; i < Count; i++)
            {
                var numberCopy = new BitStringNumber();
                var currentNumber = this[i];


                for (int j = 0; j < currentNumber.Count; j++)
                {
                    numberCopy.Add(currentNumber[j]);
                }

                numberCopy.LowerLimit = currentNumber.LowerLimit;
                numberCopy.UpperLimit = currentNumber.UpperLimit;
                numberCopy.NumberOfIntervals = currentNumber.NumberOfIntervals;

                copy.Add(numberCopy);
            }

            return copy;
        }
    }
}