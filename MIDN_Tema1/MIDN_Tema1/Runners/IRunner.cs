using System.Collections.Generic;
using MIDN_Tema1.Functions;

namespace MIDN_Tema1.Runners
{
    public interface IRunner
    {
        List<RunnerResult> Results { get; }

        string Name { get; }
        void Run(IFunction function, int numerOfInputs, int numberOfAtempts, int numberOfRuns, int numberOfIntervals);
    }
}