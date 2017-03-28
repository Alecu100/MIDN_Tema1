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
            var stream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, this);
            stream.Position = 0;

            return (BitStringSolution) binaryFormatter.Deserialize(stream);
        }
    }
}