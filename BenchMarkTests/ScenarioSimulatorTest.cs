using System;
using System.Diagnostics;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace BenchMarkTests
{
    class ScenarioSimulatorTest : ITest
    {
        private Scenario scenario;
        private IScenarioSimulator simulator;

        public ScenarioSimulatorTest(Scenario scenario, IScenarioSimulator simulator)
        {
            this.scenario = scenario;
            this.simulator = simulator;
        }

        public void Execute(ScenarioEvent e)
        {   
            simulator.Start(scenario);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            simulator.SubmitSimulatorEvent(e);

            stopwatch.Stop();

            Result = 1.0f * stopwatch.ElapsedTicks / TimeSpan.TicksPerMillisecond;

        }

        public float Result { get; private set; }
    }
}
