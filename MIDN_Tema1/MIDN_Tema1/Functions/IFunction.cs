using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Functions
{
    public interface IFunction
    {
        int NumberOfIntervals { get; set; }

        double CalculateValue(BitStringSolution solution);

        BitStringSolution GetRandomSolution(int numberOfInputs);

        string Name { get; }

        bool IsBetterThanCurrentValue(double currentValue, double newValue);
    }
}