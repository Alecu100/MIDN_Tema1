using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using MIDN_Tema1.Controls;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Runners
{
    public class HillClimbingRunner : IRunner
    {
        private string _fitMethod;
        private HillClimberSettings _hillClimberSettings;
        private int _numberOfAtempts;
        public List<RunnerResult> Results { get; } = new List<RunnerResult>();

        public string Name
        {
            get { return "Hill Climbing"; }
        }

        public UserControl RunnerSettings
        {
            get
            {
                if (_hillClimberSettings == null)
                {
                    _hillClimberSettings = new HillClimberSettings();
                }

                return _hillClimberSettings;
            }
        }

        public string OptionalFieldName
        {
            get { return "Atempt Number"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfRuns,
            int numberOfIntervals)
        {
            Results.Clear();
            function.NumberOfIntervals = numberOfIntervals;
            _numberOfAtempts = _hillClimberSettings.NumberOfAtempts;
            _fitMethod = _hillClimberSettings.SelectedFitMethod.Name;

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(function, numerOfInputs, numberOfIntervals, i);
            }
        }

        private void RunInternally(IFunction function, int numerOfInputs, int numberOfIntervals,
            int i)
        {
            var bestSolution = function.GetRandomSolution(numerOfInputs);

            for (var j = 0; j < _numberOfAtempts; j++)
            {
                var bitStringSolution = function.GetRandomSolution(numerOfInputs);

                AddResult(function, i, -2, bitStringSolution);

                var bestCurrentSolution = bitStringSolution;

                var isLocal = false;

                while (isLocal == false)
                {
                    bitStringSolution = Improve(function, bitStringSolution);

                    var bestValue = function.CalculateValue(bestCurrentSolution);
                    var currentValue = function.CalculateValue(bitStringSolution);

                    if (function.IsBetterThanCurrentValue(bestValue, currentValue))
                    {
                        bestCurrentSolution = bitStringSolution;

                        AddResult(function, i, j, bestCurrentSolution);
                    }
                    else
                    {
                        isLocal = true;
                    }
                }

                var bestValue2 = function.CalculateValue(bestSolution);
                var currentValue2 = function.CalculateValue(bestCurrentSolution);

                if (function.IsBetterThanCurrentValue(bestValue2, currentValue2))
                {
                    bestSolution = bestCurrentSolution;
                }
            }

            AddResult(function, i, -1, bestSolution);
        }

        private void AddResult(IFunction function, int index, int atempt, BitStringSolution solution)
        {
            var runnerResult = new RunnerResult();

            runnerResult.Number = index;
            runnerResult.OptionalField = atempt;
            runnerResult.Function = function.Name;
            runnerResult.Value = function.CalculateValue(solution).ToString();

            var results = new List<double>();

            var bld = new StringBuilder();

            foreach (var bitStringNumber in solution)
            {
                var currentNumber = bitStringNumber.ToDouble();
                results.Add(currentNumber);
            }

            results.Sort();

            foreach (var number in results)
            {
                bld.Append(number);
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
                        if (_fitMethod == "First Fit")
                        {
                            return improvedBitStringSolution;
                        }

                        bestSolution = improvedBitStringSolution;
                    }
                }

            return bestSolution.Copy();
        }
    }
}