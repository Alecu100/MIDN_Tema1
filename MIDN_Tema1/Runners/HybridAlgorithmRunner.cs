using System;
using System.Windows.Controls;
using MIDN_Tema1.Controls;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Runners
{
    public class HybridAlgorithmRunner : GeneticAlgorithmRunner
    {
        private double _improvementChance;

        public override UserControl RunnerSettings
        {
            get
            {
                if (_runnerSettings == null)
                {
                    _runnerSettings = new HybridAlgorithmSettings();
                }

                return _runnerSettings;
            }
        }

        public override string Name
        {
            get { return "Hybrid algorithm"; }
        }

        public override void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals)
        {
            var geneticAlgorithmSettings = (HybridAlgorithmSettings) _runnerSettings;

            _crossorverChance = geneticAlgorithmSettings.CrossoverChance;
            _crossoverCuts = geneticAlgorithmSettings.CrossoverCuts;
            _mutationChance = geneticAlgorithmSettings.MutationChance;
            _populationSize = geneticAlgorithmSettings.PopulationSize;
            _improvementChance = geneticAlgorithmSettings.ImprovementChance;

            function.NumberOfIntervals = numberOfIntervals;

            Results.Clear();

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(function, numerOfInputs, i);
            }
        }

        protected override void EvolvePopulation(IFunction function, BitSolutionsPopulation copy, int atemptCount)
        {
            base.EvolvePopulation(function, copy, atemptCount);

            ImprovePopulation(function, copy);
        }

        private void ImprovePopulation(IFunction function, BitSolutionsPopulation copy)
        {
            foreach (var solution
                in copy)
            {
                var random = new Random(RandomUtils.GetNext4Digits());

                var chance = random.NextDouble();

                if (chance < _improvementChance)
                {
                    var improvedSolution = Improve(function, solution);

                    for (var i = 0; i < solution.Count; i++)
                    {
                        for (var j = 0; j < solution[i].Count; j++)
                        {
                            solution[i][j] = improvedSolution[i][j];
                        }
                    }
                }
            }
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

                    var bestValue = function.CalculateValue(bestSolution.ToDouble());
                    var currentValue = function.CalculateValue(improvedBitStringSolution.ToDouble());

                    if (function.IsBetterThanCurrentValue(bestValue, currentValue))
                    {
                        return improvedBitStringSolution;
                    }
                }

            return bitStringSolution.Copy();
        }
    }
}