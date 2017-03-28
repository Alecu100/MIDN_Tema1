using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MIDN_Tema1.Representations
{
    [Serializable]
    public class BitStringNumber : List<byte>
    {
        public double LowerLimit { get; set; }

        public double UpperLimit { get; set; }

        public int NumberOfBits
        {
            get { return (int) System.Math.Ceiling(System.Math.Log(NumberOfIntervals, 2)); }
        }

        public double NumberOfIntervals { get; set; }

        public double ToDouble()
        {
            var decimalPlate = 1;
            var decimalValue = 0;
            var computedValue = LowerLimit;

            for (var i = 0; i < Count; i++, decimalPlate *= 2)
            {
                if (this[i] != 0)
                {
                    decimalValue += decimalPlate;
                }
            }

            computedValue += decimalValue/(System.Math.Pow(2, NumberOfBits) - 1)*(UpperLimit - LowerLimit);

            return computedValue;
        }

        public BitStringNumber Copy()
        {
            var stream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, this);
            stream.Position = 0;

            return (BitStringNumber) binaryFormatter.Deserialize(stream);
        }
    }
}