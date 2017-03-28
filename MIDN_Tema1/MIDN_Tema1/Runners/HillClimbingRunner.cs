using System.Collections.Generic;
using System.Text;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Runners
{
    public class HillClimbingRunner : IRunner
    {
        public List<RunnerResult> Results { get; } = new List<RunnerResult>();

        public string Name
        {
            get { return "Hill Climbing"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfAtempts, int numberOfRuns,
            int numberOfIntervals)
        {
            Results.Clear();
            function.NumberOfIntervals = numberOfIntervals;

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(function, numerOfInputs, numberOfAtempts, numberOfIntervals, i);
            }
        }

        private void RunInternally(IFunction function, int numerOfInputs, int numberOfAtempts, int numberOfIntervals,
            int i)
        {
            BitStringSolution bestSolution = null;

            for (var j = 0; j < numberOfAtempts; j++)
            {
                var bitStringSolution = function.GetRandomSolution(numerOfInputs);

                bitStringSolution = Improve(function, bitStringSolution);

                if (j == 0)
                {
                    bestSolution = bitStringSolution;
                }
                else
                {
                    var bestValue = function.CalculateValue(bestSolution);
                    var currentValue = function.CalculateValue(bitStringSolution);

                    if (function.IsBetterThanCurrentValue(bestValue, currentValue))
                    {
                        bestSolution = bitStringSolution;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            var runnerResult = new RunnerResult();

            runnerResult.Number = i;
            runnerResult.Function = function.Name;
            runnerResult.Value = function.CalculateValue(bestSolution).ToString();

            var bld = new StringBuilder();

            foreach (var bitStringNumber in bestSolution)
            {
                var currentNumber = bitStringNumber.ToDouble();
                bld.Append(currentNumber);
                bld.Append(" ; ");
            }

            bld.Remove(bld.Length - 3, 3);

            runnerResult.Inputs = bld.ToString();
            runnerResult.Runner = Name;

            Results.Add(runnerResult);
        }

        private BitStringSolution Improve(IFunction function, BitStringSolution bitStringSolution)
        {
            var bestSolution = bitStringSolution.Copy();

            for (var i = 0; i < bitStringSolution.Count; i++)
                for (var j = 0; j < bitStringSolution[i].Count; j++)
                {
                    var improvedBitStringSolution = bitStringSolution.Copy();

                    if (improvedBitStringSolution[i][j] != 0)
                    {
                        improvedBitStringSolution[i][j] = 0;
                    }
                    else
                    {
                        improvedBitStringSolution[i][j] = 1;
                    }

                    var bestValue = function.CalculateValue(bestSolution);
                    var currentValue = function.CalculateValue(improvedBitStringSolution);

                    if (function.IsBetterThanCurrentValue(bestValue, currentValue))
                    {
                        bestSolution = improvedBitStringSolution;
                    }
                }

            return bestSolution;
        }
    }
}