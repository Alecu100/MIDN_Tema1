using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MIDN_Tema1.Functions;

namespace MIDN_Tema1.Runners
{
    public class ParticleSwarmRunner : IRunner
    {
        public List<RunnerResult> Results { get; } = new List<RunnerResult>();

        public string Name
        {
            get { return "Particle Swarm"; }
        }

        public UserControl RunnerSettings { get; }

        public string OptionalFieldName
        {
            get { return "Particle"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals)
        {
            throw new NotImplementedException();
        }
    }
}