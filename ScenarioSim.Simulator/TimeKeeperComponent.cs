using System;
using System.Collections.Generic;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class TimeKeeperComponent : ISimulationComponent
    {
        readonly IScenarioSimulator simulator;
        Dictionary<string, long> times;
        long previousTime;
        IEnumerable<string> previousTasks;

        public IDictionary<string, long> TaskTimes {
            get { return times; }
        }

        public TimeKeeperComponent(IScenarioSimulator simulator)
        {
            this.simulator = simulator;
        }

        public void Start()
        {
            times = new Dictionary<string, long>();
            previousTasks = simulator.ActiveTasks();
            previousTime = DateTime.Now.Ticks;
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            long currentTime = e.Timestamp.Ticks;
            long deltaTime = currentTime - previousTime;

            foreach(string task in previousTasks)
                times[task] += deltaTime;

            previousTasks = simulator.ActiveTasks();
            previousTime = currentTime;
        }

        public void Complete()
        {
            long currentTime = DateTime.Now.Ticks;
            long deltaTime = currentTime - previousTime;

            foreach (string task in previousTasks)
                times[task] += deltaTime;
        }
    }
}
