using System;
using System.Diagnostics;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace BenchMarkTests
{
    class ComponentTest : ITest
    {
        private ISimulationComponent component;

        public ComponentTest(ISimulationComponent component)
        {
            this.component = component;
        }

        public void Execute(ScenarioEvent e)
        {
            
            Stopwatch timer = new Stopwatch();

            component.Start();

            timer.Start();
            component.SubmitEvent(e);
            timer.Stop();

            component.Complete();

            Result = 1.0f * timer.ElapsedTicks / TimeSpan.TicksPerMillisecond;
        }

        public float Result { get; private set; }
    }
}
