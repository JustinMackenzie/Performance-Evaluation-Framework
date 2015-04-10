using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
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

            UpdateTimes(deltaTime);

            previousTasks = simulator.ActiveTasks();
            previousTime = currentTime;
        }

        private void UpdateTimes(long deltaTime)
        {
            foreach (string task in previousTasks)
            {
                if (times.ContainsKey(task))
                    times[task] += deltaTime;
                else
                    times.Add(task, deltaTime);
            }
        }

        public void Complete()
        {
            long currentTime = DateTime.Now.Ticks;
            long deltaTime = currentTime - previousTime;

            UpdateTimes(deltaTime);
        }
    }
}
