using System;
using System.Collections.Generic;

namespace MIDN_Tema1.Representations
{
    [Serializable]
    public class BitSolutionsPopulation : List<BitStringSolution>
    {
        public BitSolutionsPopulation Copy()
        {
            var solutionsPopulation = new BitSolutionsPopulation();

            for (var i = 0; i < Count; i++)
            {
                solutionsPopulation.Add(this[i].Copy());
            }

            return solutionsPopulation;
        }
    }
}