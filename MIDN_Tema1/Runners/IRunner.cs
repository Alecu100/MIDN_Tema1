using System.Collections.Generic;
using System.Windows.Controls;
using MIDN_Tema1.Functions;

namespace MIDN_Tema1.Runners
{
    public interface IRunner
    {
        List<RunnerResult> Results { get; }

        string Name { get; }

        UserControl RunnerSettings { get; }

        string OptionalFieldName { get; }
        void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals);
    }
}