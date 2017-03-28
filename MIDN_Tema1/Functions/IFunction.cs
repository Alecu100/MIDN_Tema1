using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public interface IFunction
    {
        int NumberOfIntervals { get; set; }

        string Name { get; }

        double CalculateValue(BitStringSolution solution);

        double CalculateMaximizationValue(BitStringSolution solution);

        BitStringSolution GetRandomSolution(int numberOfInputs);

        bool IsBetterThanCurrentValue(double currentValue, double newValue);
    }
}