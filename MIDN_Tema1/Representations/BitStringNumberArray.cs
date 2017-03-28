using System.Collections.Generic;
using System.Linq;

namespace MIDN_Tema1.Representations
{
    public class BitStringNumberArray : List<byte>
    {
        public void LoadFromSolution(BitStringSolution solution)
        {
            Clear();

            for (var i = 0; i < solution.Count; i++)
                for (var j = 0; j < solution[i].Count; j++)
                {
                    Add(solution[i][j]);
                }
        }

        public void UnloadToSolution(BitStringSolution solution)
        {
            var k = 0;

            for (var i = 0; i < solution.Count; i++)
                for (var j = 0; j < solution[i].Count; j++)
                {
                    solution[i][j] = this[k];
                    k++;
                }
        }

        public void Crossover(BitStringNumberArray otherArray, List<int> crossoverPoints)
        {
            crossoverPoints.Sort();

            var insideCrossover = false;

            for (var i = 0; i < Count && i < otherArray.Count; i++)
            {
                if (crossoverPoints.Any(crossoverPoint => crossoverPoint == i))
                {
                    insideCrossover = !insideCrossover;
                }

                if (insideCrossover)
                {
                    var temp = this[i];
                    this[i] = otherArray[i];
                    otherArray[i] = temp;
                }
            }
        }
    }
}