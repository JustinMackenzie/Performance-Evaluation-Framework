using System;
using System.Diagnostics;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace BenchMarkTests
{
    class ComponentTest : ITest
    {
        private ISimulationComponent component;
        private Scenario scenario;

        public ComponentTest(ISimulationComponent component, Scenario scenario)
        {
            this.component = component;
            this.scenario = scenario;
        }

        public void Execute(ScenarioEvent e)
        {
            
            Stopwatch timer = new Stopwatch();

            component.Start(scenario);

            timer.Start();
            component.SubmitEvent(e);
            timer.Stop();

            component.Complete();

            Result = 1.0f * timer.ElapsedTicks / TimeSpan.TicksPerMillisecond;
        }

        public float Result { get; private set; }
    }
}
