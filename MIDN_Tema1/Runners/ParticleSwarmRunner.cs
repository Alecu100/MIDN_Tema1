using System.Collections.Generic;
using System.Windows.Controls;
using MIDN_Tema1.Controls;
using MIDN_Tema1.Functions;

namespace MIDN_Tema1.Runners
{
    public class ParticleSwarmRunner : IRunner
    {
        private ParticleSwarmSettings _runnerSettings;
        private int _swarmSize;
        private double _w1Factor;
        private double _w2Factor;
        private double _w3Factor;
        public List<RunnerResult> Results { get; } = new List<RunnerResult>();

        public string Name
        {
            get { return "Particle Swarm"; }
        }

        public UserControl RunnerSettings
        {
            get
            {
                if (_runnerSettings == null)
                {
                    _runnerSettings = new ParticleSwarmSettings();
                }

                return _runnerSettings;
            }
        }

        public string OptionalFieldName
        {
            get { return "Particle"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals)
        {
            _swarmSize = _runnerSettings.SwarmSize;
            _w1Factor = _runnerSettings.W1Factor;
            _w2Factor = _runnerSettings.W2Factor;
            _w3Factor = _runnerSettings.W3Factor;

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(numerOfInputs, i);
            }
        }

        private void RunInternally(int numerOfInputs, int i)
        {
        }
    }
}