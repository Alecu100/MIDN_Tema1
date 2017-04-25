using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using MIDN_Tema1.Controls;
using MIDN_Tema1.Functions;
using MIDN_Tema1.Representations;

namespace MIDN_Tema1.Runners
{
    public class ParticleSwarmRunner : IRunner
    {
        private int _iterations;
        private ParticleSwarmSettings _runnerSettings;
        private int _swarmSize;
        private double _velocityClampRatio;
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
            get { return "Iteration"; }
        }

        public void Run(IFunction function, int numerOfInputs, int numberOfRuns, int numberOfIntervals)
        {
            Results.Clear();

            _swarmSize = _runnerSettings.SwarmSize;
            _w1Factor = _runnerSettings.W1Factor;
            _w2Factor = _runnerSettings.W2Factor;
            _w3Factor = _runnerSettings.W3Factor;
            _velocityClampRatio = _runnerSettings.VelocityClampRatio;
            _iterations = _runnerSettings.Iterations;

            for (var i = 0; i < numberOfRuns; i++)
            {
                RunInternally(function, numerOfInputs, i);
            }
        }

        private void AddParticleToResults(IFunction function, Particle particle, string iteration, int runNumber)
        {
            var runnerResult = new RunnerResult();

            runnerResult.Runner = Name;
            runnerResult.Number = runNumber;
            runnerResult.OptionalField = iteration;
            runnerResult.Value = function.CalculateValue(particle.ToDouble()).ToString(CultureInfo.InvariantCulture);

            var stringBuilder = new StringBuilder();

            for (var j = 0; j < particle.Count; j++)
            {
                stringBuilder.Append("val: " + particle[j].Value + "  vel:" + particle[j].Velocity + ",");
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            runnerResult.Inputs = stringBuilder.ToString();

            Results.Add(runnerResult);
        }

        private void RunInternally(IFunction function, int numerOfInputs, int runNumber)
        {
            var particleSwarm = new ParticleSwarm();

            for (var i = 0; i < _swarmSize; i++)
            {
                var randomParticle = function.GetRandomParticle(numerOfInputs);

                for (var j = 0; j < randomParticle.Count; j++)
                {
                    var next4Digits = RandomUtils.GetNext4Digits();
                    var random = new Random(next4Digits);

                    var bruteVelocity = random.NextDouble();

                    randomParticle[j].Velocity = bruteVelocity*_velocityClampRatio*
                                                 (randomParticle[j].UpperLimit - randomParticle[j].LowerLimit);
                }

                randomParticle.Maximum = randomParticle.Copy();

                particleSwarm.Add(randomParticle);
            }

            particleSwarm.GlobalMaximum = particleSwarm[0].Copy();

            for (var i = 0; i < particleSwarm.Count; i++)
            {
                AddParticleToResults(function, particleSwarm[i], "initial iteration", runNumber);
            }

            for (var i = 1; i < _swarmSize; i++)
            {
                var currentBestValue = function.CalculateValue(particleSwarm.GlobalMaximum.ToDouble());
                var currentValue = function.CalculateValue(particleSwarm[i].ToDouble());

                if (function.IsBetterThanCurrentValue(currentBestValue, currentValue))
                {
                    particleSwarm.GlobalMaximum = particleSwarm[i].Copy();
                }
            }

            for (var iteration = 0; iteration < _iterations; iteration++)
            {
                for (var i = 0; i < particleSwarm.Count; i++)
                {
                    UpdateVelocity(particleSwarm[i], particleSwarm.GlobalMaximum);

                    UpdatePosition(particleSwarm[i]);

                    var currentBestGlobalValue = function.CalculateValue(particleSwarm.GlobalMaximum.ToDouble());
                    var currentBestValue = function.CalculateValue(particleSwarm[i].Maximum.ToDouble());
                    var currentValue = function.CalculateValue(particleSwarm[i].ToDouble());

                    if (function.IsBetterThanCurrentValue(currentBestGlobalValue, currentValue))
                    {
                        particleSwarm.GlobalMaximum = particleSwarm[i].Copy();
                    }

                    if (function.IsBetterThanCurrentValue(currentBestValue, currentValue))
                    {
                        particleSwarm[i].Maximum = particleSwarm[i].Copy();
                    }

                    AddParticleToResults(function, particleSwarm[i], iteration.ToString(), runNumber);
                }
            }

            AddParticleToResults(function, particleSwarm.GlobalMaximum, "global maximum", runNumber);
        }

        private void UpdatePosition(Particle particle)
        {
            for (var i = 0; i < particle.Count; i++)
            {
                particle[i].Value = particle[i].Value + particle[i].Velocity;

                if (particle[i].Value < particle[i].LowerLimit)
                {
                    particle[i].Value = particle[i].LowerLimit;
                }

                if (particle[i].Value > particle[i].UpperLimit)
                {
                    particle[i].Value = particle[i].UpperLimit;
                }
            }
        }

        private void UpdateVelocity(Particle particle, Particle globalMaximumParticle)
        {
            for (var i = 0; i < particle.Count; i++)
            {
                var next4Digits = RandomUtils.GetNext4Digits();
                var random = new Random(next4Digits);

                particle[i].Velocity = _w1Factor*particle[i].Velocity +
                                       _w2Factor*random.NextDouble()*(particle.Maximum[i].Value - particle[i].Value) +
                                       _w3Factor*random.NextDouble()*
                                       (globalMaximumParticle[i].Value - particle[i].Value);

                if (Math.Abs(particle[i].Velocity) >
                    Math.Abs(_velocityClampRatio*(particle[i].UpperLimit - particle[i].LowerLimit)))
                {
                    particle[i].Velocity = Math.Sign(particle[i].Velocity)*
                                           Math.Abs(_velocityClampRatio*
                                                    (particle[i].UpperLimit - particle[i].LowerLimit));
                }
            }
        }
    }
}