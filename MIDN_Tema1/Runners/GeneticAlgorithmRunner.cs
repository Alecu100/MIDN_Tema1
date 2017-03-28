using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MIDN_Tema1.Controls;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Runners
{
    public class GeneticAlgorithmRunner : IRunner

    {
        private readonly List<RunnerResult> _results = new List<RunnerResult>();
        private GeneticAlgorithmSettings _runnerSettings;

        public List<RunnerResult> Results
        {
            get { return _results; }
        }

        public string Name
        {
            get { return "Genetic algorithm"; }
        }

        public UserControl RunnerSettings
        {
            get
            {
                if (_runnerSettings == null)
                {
                    _runnerSettings = new GeneticAlgorithmSettings();
                }

                return _runnerSettings;
            }
        }

        public string OptionalFieldName
        {
            get { return "Population Number"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals)
        {
            var crossoverChance = _runnerSettings.CrossoverChance;
            var crossoverCuts = _runnerSettings.CrossoverCuts;
            var mutationChance = _runnerSettings.MutationChance;
            var populationSize = _runnerSettings.PopulationSize;

            function.NumberOfIntervals = numberOfIntervals;

            Results.Clear();

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(function, numerOfInputs, populationSize, mutationChance,
                    crossoverChance, crossoverCuts,
                    i);
            }
        }

        private void RunInternally(IFunction function, int numerOfInputs, int populationSize,
            double mutationChance, double crossorverChance, int crossoverCuts, int i)
        {
            var currentPopulation = GenerateInitialPopulation(function, numerOfInputs, populationSize);

            AddPopulationToResults(function, currentPopulation, i, 0);

            var shouldContinueEvolution = true;
            var populationNumber = 0;

            while (shouldContinueEvolution)
            {
                var atemptCount = 0;
                shouldContinueEvolution = false;

                while (atemptCount < 50)
                {
                    var newPopulation = currentPopulation.Copy();

                    PerformSelection(newPopulation, function);
                    EvolvePopulation(newPopulation, mutationChance, crossorverChance, crossoverCuts, atemptCount);

                    if (IsBetterThanCurrentPopulation(function, currentPopulation, newPopulation))
                    {
                        currentPopulation = newPopulation;
                        shouldContinueEvolution = true;
                        populationNumber++;
                        AddPopulationToResults(function, currentPopulation, i, populationNumber);
                        break;
                    }

                    atemptCount++;
                }
            }
        }

        private void AddPopulationToResults(IFunction function, BitSolutionsPopulation currentPopulation, int runNumber,
            int populationNumber)
        {
            for (var i = 0; i < currentPopulation.Count; i++)
            {
                var runnerResult = new RunnerResult();

                runnerResult.Runner = Name;
                runnerResult.Function = function.Name;
                runnerResult.Number = runNumber;
                runnerResult.Value = function.CalculateValue(currentPopulation[i]).ToString();
                runnerResult.OptionalField = populationNumber;
                var results = new List<double>();

                var bld = new StringBuilder();

                foreach (var bitStringNumber in currentPopulation[i])
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

                Results.Add(runnerResult);
            }
        }

        private bool IsBetterThanCurrentPopulation(IFunction function, BitSolutionsPopulation currentPopulation,
            BitSolutionsPopulation newPopulation)
        {
            var maxFromCurrentPopulation = function.CalculateMaximizationValue(currentPopulation[0]);

            for (var i = 1; i < currentPopulation.Count; i++)
            {
                var maxFromCurrentSolution = function.CalculateMaximizationValue(currentPopulation[i]);

                if (maxFromCurrentSolution > maxFromCurrentPopulation)
                {
                    maxFromCurrentPopulation = maxFromCurrentSolution;
                }
            }

            var maxFromNewPopulation = function.CalculateMaximizationValue(newPopulation[0]);

            for (var i = 1; i < newPopulation.Count; i++)
            {
                var maxFromNewSolution = function.CalculateMaximizationValue(newPopulation[i]);

                if (maxFromNewSolution > maxFromNewPopulation)
                {
                    maxFromNewPopulation = maxFromNewSolution;
                }
            }

            return maxFromNewPopulation > maxFromCurrentPopulation;
        }

        private void PerformSelection(BitSolutionsPopulation newPopulation, IFunction function)
        {
            var copy = newPopulation.Copy();

            newPopulation.Clear();

            var totalFitness = 0d;
            var currentPoint = 0d;

            for (var i = 0; i < copy.Count; i++)
            {
                totalFitness += function.CalculateMaximizationValue(copy[i]);
            }

            var intervals = new List<Tuple<double, double, int>>();

            double lowerLimit;
            for (var i = 0; i < copy.Count - 1; i++)
            {
                lowerLimit = currentPoint;

                currentPoint += function.CalculateMaximizationValue(copy[i])/totalFitness;

                var upperLimit = currentPoint;

                intervals.Add(new Tuple<double, double, int>(lowerLimit, upperLimit, i));
            }

            intervals.Add(new Tuple<double, double, int>(currentPoint, 1, copy.Count - 1));

            for (var i = 0; i < copy.Count; i++)
            {
                var random = new Random(RandomUtils.GetNext4Digits());

                var currentIndex = random.NextDouble();

                var selectedSolutionIndex =
                    intervals.First(interval => interval.Item1 <= currentIndex && interval.Item2 > currentIndex);

                var selectedSolution = copy[selectedSolutionIndex.Item3].Copy();

                newPopulation.Add(selectedSolution);
            }
        }

        private void EvolvePopulation(BitSolutionsPopulation copy, double mutationChance, double crossoverChance,
            double crossoverCuts, int atemptCount)
        {
            MutatePopulation(copy, mutationChance, atemptCount);

            CrossoverPopulation(copy, crossoverChance, crossoverCuts);
        }

        private void CrossoverPopulation(BitSolutionsPopulation copy, double crossoverChance, double crossoverCuts)
        {
            var solutionsToCrossover = new List<BitStringSolution>();

            for (var i = 0; i < copy.Count; i++)
            {
                var random = new Random(RandomUtils.GetNext4Digits());


                if (random.NextDouble() <= crossoverChance)
                {
                    solutionsToCrossover.Add(copy[i]);
                }
            }

            if (solutionsToCrossover.Count%2 == 1)
            {
                if (solutionsToCrossover.Count == copy.Count)
                {
                    var random = new Random(RandomUtils.GetNext4Digits());

                    var solutionToRemove = random.Next(0, solutionsToCrossover.Count);
                    solutionsToCrossover.RemoveAt(solutionToRemove);
                }
                else
                {
                    var random = new Random(RandomUtils.GetNext4Digits());

                    var addRemoveChance = random.NextDouble();

                    if (addRemoveChance <= 0.5 && solutionsToCrossover.Count >= 3)
                    {
                        random = new Random(RandomUtils.GetNext4Digits());

                        var solutionToRemove = random.Next(0, solutionsToCrossover.Count);
                        solutionsToCrossover.RemoveAt(solutionToRemove);
                    }
                    else
                    {
                        random = new Random(RandomUtils.GetNext4Digits());

                        var remainingSolutions =
                            copy.Where(
                                solution => solutionsToCrossover.All(selecteSolution => selecteSolution != solution))
                                .ToList();


                        var solutionToAdd = random.Next(0, remainingSolutions.Count);
                        solutionsToCrossover.Add(remainingSolutions[solutionToAdd]);
                    }
                }
            }

            while (solutionsToCrossover.Count > 0)
            {
                var random = new Random(RandomUtils.GetNext4Digits());

                var firstSolutionToCrossover = solutionsToCrossover[random.Next(0, solutionsToCrossover.Count)];

                solutionsToCrossover.Remove(firstSolutionToCrossover);

                var secondSolutionToCrossover = solutionsToCrossover[random.Next(0, solutionsToCrossover.Count)];

                solutionsToCrossover.Remove(secondSolutionToCrossover);

                var firstSolutionBitArray = new BitStringNumberArray();
                var secondSolutionBitArray = new BitStringNumberArray();

                firstSolutionBitArray.LoadFromSolution(firstSolutionToCrossover);
                secondSolutionBitArray.LoadFromSolution(secondSolutionToCrossover);

                var crossoverCutPoints = new List<int>();

                for (var i = 0; i < crossoverCuts; i++)
                {
                    var j = 0;

                    do
                    {
                        random = new Random(RandomUtils.GetNext4Digits() + i + j);

                        var newPoint = random.Next(0, firstSolutionBitArray.Count);

                        if (!crossoverCutPoints.Contains(newPoint))
                        {
                            crossoverCutPoints.Add(newPoint);
                            break;
                        }

                        j++;
                    } while (true);
                }

                firstSolutionBitArray.Crossover(secondSolutionBitArray, crossoverCutPoints);

                firstSolutionBitArray.UnloadToSolution(firstSolutionToCrossover);
                secondSolutionBitArray.UnloadToSolution(secondSolutionToCrossover);
            }
        }

        private void MutatePopulation(BitSolutionsPopulation copy, double mutationChance, int atemptCount)
        {
            for (var i = 0; i < copy.Count; i++)
            {
                var ticks = (int) (DateTime.Now.Ticks%int.MaxValue/2);
                var random = new Random(i + atemptCount + ticks);

                if (random.NextDouble() <= mutationChance)
                {
                    var currentSolution = copy[i];

                    random = new Random(i + atemptCount + ticks + 3);

                    var numberToMutate = random.Next(0, currentSolution.Count);

                    var bitToMutate = random.Next(0, currentSolution[numberToMutate].NumberOfBits);

                    if (currentSolution[numberToMutate][bitToMutate] == 0)
                    {
                        currentSolution[numberToMutate][bitToMutate] = 1;
                    }
                    else
                    {
                        currentSolution[numberToMutate][bitToMutate] = 0;
                    }
                }
            }
        }

        private BitSolutionsPopulation GenerateInitialPopulation(IFunction function, int numerOfInputs,
            int populationSize)
        {
            var bitSolutionsPopulation = new BitSolutionsPopulation();

            for (var j = 0; j < populationSize; j++)
            {
                var bitStringSolution = function.GetRandomSolution(numerOfInputs);

                bitSolutionsPopulation.Add(bitStringSolution);
            }

            return bitSolutionsPopulation;
        }
    }
}